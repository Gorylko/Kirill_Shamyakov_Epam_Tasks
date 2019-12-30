namespace FinanceAnalyzer.UI
{
    using System;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Business.Services.Interfaces;
    using FinanceAnalyzer.Shared.Entities;
    using FinanceAnalyzer.Shared.Enums;
    using FinanceAnalyzer.Shared.Exceptions;
    using FinanceAnalyzer.UI.Interfaces;

    internal class AppLauncher : ILauncher
    {
        private const int MaxAttemptsNumber = 3;

        private readonly IFinanceService<decimal> _financeService;
        private readonly IDataReceiver _dataReceiver;
        private readonly ILoginService _loginService;
        private readonly ICookieManager _cookieManager;
        private readonly IDisplayer _displayer;

        private User _currentUser;
        private bool _isAppOn;

        public AppLauncher(
            IFinanceService<decimal> financeService,
            IDataReceiver dataReceiver,
            ILoginService loginService,
            ICookieManager authorizer,
            IDisplayer displayer)
        {
            _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
            _dataReceiver = dataReceiver ?? throw new ArgumentNullException(nameof(dataReceiver));
            _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
            _cookieManager = authorizer ?? throw new ArgumentNullException(nameof(authorizer));
            _displayer = displayer ?? throw new ArgumentNullException(nameof(displayer));

            _isAppOn = true;
        }

        public async Task Launch()
        {
            _currentUser = await _cookieManager.GetUserFromCookie();

            if (_currentUser == null)
            {
                _currentUser = await LoginInApp() ?? throw new InvalidLoginException("Invalid login");
            }

            while (_isAppOn)
            {
                _displayer.DisplayStartMenu();
                await PerformAction(_dataReceiver.GetAction());
            }
        }

        private async Task PerformAction(ActionType action)
        {
            switch (action)
            {
                case ActionType.DisplayIncome:
                    _displayer.DisplayIncome(await _financeService.GetIncomeHistory());
                    break;
                case ActionType.DisplayExpenses:
                    _displayer.DisplayExpenses(await _financeService.GetExpenseHistory());
                    break;
                case ActionType.DisplayFullInformation:
                    _displayer.DisplayFullInformation(await _financeService.GetFullInformation());
                    break;
                case ActionType.AddNewIncome:
                    await AddNewIncome();
                    break;
                case ActionType.AddNewExpense:
                    await AddNewExpense();
                    break;
                case ActionType.ClearHistory:
                    await _financeService.ClearHistory();
                    break;
                case ActionType.Exit:
                    TurnOffApp();
                    break;
                case ActionType.Logout:
                    _cookieManager.DeleteCookies();
                    TurnOffApp();
                    break;
                default:
                    break;
            }
        }

        private async Task AddNewIncome()
        {
            for (int currentAttempt = 1; currentAttempt <= MaxAttemptsNumber; currentAttempt++)
            {
                _displayer.DisplayMessage("Enter new income", isClearAll: true);
                if (_dataReceiver.TryGetDecimal(out var inputResult))
                {
                    await _financeService.AddNewIncome(inputResult);
                    return;
                }

                _displayer.DisplayErrorMessage("Try again :(");
            }

            _displayer.DisplayNotification("Ended typing attempts");
        }

        private async Task AddNewExpense()
        {
            for (int currentAttempt = 1; currentAttempt <= MaxAttemptsNumber; currentAttempt++)
            {
                _displayer.DisplayMessage("Enter new expense", isClearAll: true);
                if (_dataReceiver.TryGetDecimal(out var inputResult))
                {
                    await _financeService.AddNewExpense(inputResult);
                    return;
                }

                _displayer.DisplayErrorMessage("Try again :(");
            }

            _displayer.DisplayNotification("Ended typing attempts");
        }

        private async Task<User> LoginInApp()
        {
            for (int currentAttempt = 1; currentAttempt <= MaxAttemptsNumber; currentAttempt++)
            {
                _displayer.DisplayMessage("Enter your login");
                string loginString = _dataReceiver.GetString();

                _displayer.DisplayMessage("Enter your password", isOnFreePlace: true);
                string passwordString = _dataReceiver.GetString(isOnFreePlace: true);

                if (loginString == null
                    && passwordString == null)
                {
                    continue;
                }

                var user = await _loginService.Login(loginString, passwordString);

                if (user != null)
                {
                    await _cookieManager.SaveUserCookie(user);
                    return user;
                }

                _displayer.DisplayErrorMessage("Try again :(");
            }

            return default;
        }

        private void TurnOffApp()
        {
            _isAppOn = false;
        }
    }
}

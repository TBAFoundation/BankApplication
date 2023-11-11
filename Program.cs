using System.Globalization;

using BankApplication;

IAccountManager accountManager = new AccountManager();
Menu menu = new Menu(accountManager);
menu.DisplayMenu();


CultureInfo culture = new CultureInfo("en-NG");
Thread.CurrentThread.CurrentCulture = culture;
Thread.CurrentThread.CurrentUICulture = culture;

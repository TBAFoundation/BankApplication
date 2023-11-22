using BankApplication;

IAccountManager accountManager = new AccountManager();
Menu menu = new Menu(accountManager);
menu.DisplayMenu();
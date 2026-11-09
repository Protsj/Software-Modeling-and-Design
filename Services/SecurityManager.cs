namespace StoreAutomatization.Services;

public enum UserRole { None, Cashier, Admin }
public static class SecurityManager
{
    public static UserRole CurrentRole { get; private set; } = UserRole.None;

    public static bool Authenticate(string username, string password)
    {
        if (username == "admin" && password == "admin123")
        {
            CurrentRole = UserRole.Admin;
            Logger.LogInfo("Аутентифікація успішна. Роль: {Role}", "Адміністратор");
            return true;
        }
        if (username == "cashier" && password == "cashier123")
        {
            CurrentRole = UserRole.Cashier;
            Logger.LogInfo("Аутентифікація успішна. Роль: {Role}", "Касир");
            return true;
        }
        
        Logger.LogError("Помилка безпеки: Невірний логін або пароль для користувача '{Username}'.", username);

        CurrentRole = UserRole.None;
        return false;
    }

    public static void Logout()
    {
        CurrentRole = UserRole.None;
        Logger.LogInfo("Користувач вийшов із системи.");
    }
}

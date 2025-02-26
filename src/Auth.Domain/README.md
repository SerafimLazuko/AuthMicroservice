
# Доменный слой

## Модели

### 1. **User** (Пользователь)

**Описание:**

Модель `User` представляет учетную запись пользователя в системе.

**Свойства:**

- `Id` (`Guid`): Уникальный идентификатор пользователя.
- `Username` (`string`): Имя пользователя.
- `Email` (`string`): Адрес электронной почты пользователя.
- `PasswordHash` (`string`): Хэш пароля пользователя.
- `SecurityStamp` (`string`): Метка безопасности для отслеживания изменений в учетной записи.
- `Roles` (`ICollection<Role>`): Коллекция ролей, назначенных пользователю.
- `Claims` (`ICollection<Claim>`): Коллекция утверждений, связанных с пользователем.

**Отношения:**

- **Многие-ко-многим** с моделью `Role`: Пользователь может иметь несколько ролей, роль может быть назначена нескольким пользователям.
- **Один-ко-многим** с моделью `Claim`: Пользователь может иметь множество утверждений.

---

### 2. **Role** (Роль)

**Описание:**

Модель `Role` представляет роль в системе, определяющую набор прав и разрешений.

**Свойства:**

- `Id` (`Guid`): Уникальный идентификатор роли.
- `Name` (`string`): Имя роли.
- `NormalizedName` (`string`): Нормализованное имя роли для поиска.
- `Claims` (`ICollection<Claim>`): Коллекция утверждений, связанных с ролью.

**Отношения:**

- **Многие-ко-многим** с моделью `User`: Роль может быть назначена нескольким пользователям.
- **Один-ко-многим** с моделью `Claim`: Роль может иметь множество утверждений.

---

### 3. **Client** (Клиент)

**Описание:**

Модель `Client` представляет приложение или сервис, который может запрашивать токены у сервера авторизации.

**Свойства:**

- `ClientId` (`string`): Уникальный идентификатор клиента.
- `Name` (`string`): Название клиента.
- `Secrets` (`ICollection<ClientSecret>`): Коллекция секретов клиента.
- `AllowedGrantTypes` (`ICollection<string>`): Разрешенные типы грантов для клиента.
- `RedirectUris` (`ICollection<string>`): URL-адреса для перенаправления после аутентификации.
- `PostLogoutRedirectUris` (`ICollection<string>`): URL-адреса для перенаправления после выхода.
- `AllowedScopes` (`ICollection<string>`): Разрешенные скоупы для клиента.

**Отношения:**

- **Один-ко-многим** с моделью `ClientSecret`: Клиент может иметь несколько секретов.

---

### 4. **ClientSecret** (Секрет клиента)

**Описание:**

Модель `ClientSecret` представляет секрет, используемый для аутентификации клиента на сервере авторизации.

**Свойства:**

- `Value` (`string`): Значение секрета (в хешированном виде).
- `Type` (`string`): Тип секрета (по умолчанию `SharedSecret`).
- `Expiration` (`DateTime?`): Дата истечения срока действия секрета.
- `Description` (`string`): Описание секрета.

**Отношения:**

- **Многие-к-одному** с моделью `Client`: Секрет принадлежит одному клиенту.

---

### 5. **ApiResource** (API Ресурс)

**Описание:**

Модель `ApiResource` представляет защищенный ресурс или API, доступ к которому может быть предоставлен по токену доступа.

**Свойства:**

- `Name` (`string`): Уникальное имя API ресурса.
- `DisplayName` (`string`): Отображаемое имя ресурса.
- `Scopes` (`ICollection<ApiScope>`): Коллекция скоупов, связанных с ресурсом.

**Отношения:**

- **Один-ко-многим** с моделью `ApiScope`: API ресурс может иметь несколько скоупов.

---

### 6. **ApiScope** (API Скоуп)

**Описание:**

Модель `ApiScope` определяет уровень доступа или разрешения к API ресурсам.

**Свойства:**

- `Name` (`string`): Уникальное имя скоупа.
- `DisplayName` (`string`): Отображаемое имя скоупа.
- `UserClaims` (`ICollection<string>`): Коллекция утверждений, предоставляемых при запросе данного скоупа.

**Отношения:**

- **Многие-к-одному** с моделью `ApiResource`: Скоуп принадлежит одному API ресурсу.

---

## Сервисы

### 1. **IUserService**

**Описание:**

Сервис для управления пользователями и их учетными записями.

**Методы:**

- `Task<User> RegisterUserAsync(string username, string email, string password)`: Регистрация нового пользователя.
- `Task<bool> ValidateUserCredentialsAsync(string username, string password)`: Проверка учетных данных пользователя.
- `Task<User> FindByUsernameAsync(string username)`: Поиск пользователя по имени.
- `Task<User> FindByIdAsync(Guid userId)`: Поиск пользователя по идентификатору.

---

### 2. **IRoleService**

**Описание:**

Сервис для управления ролями и разрешениями в системе.

**Методы:**

- `Task<Role> CreateRoleAsync(string roleName)`: Создание новой роли.
- `Task AssignRoleToUserAsync(Guid userId, string roleName)`: Назначение роли пользователю.
- `Task<ICollection<Role>> GetUserRolesAsync(Guid userId)`: Получение ролей пользователя.

---

### 3. **IAuthenticationService**

**Описание:**

Сервис для аутентификации пользователей и управления их сессиями.

**Методы:**

- `Task<AuthenticationResult> AuthenticateAsync(string username, string password)`: Аутентификация пользователя по учетным данным.
- `Task<AuthenticationResult> AuthenticateWithExternalProviderAsync(string provider, ExternalLoginInfo loginInfo)`: Аутентификация через внешнего провайдера.
- `Task LogoutAsync()`: Выход пользователя из системы.

---

### 4. **ITokenService**

**Описание:**

Сервис для создания, валидации и обновления токенов доступа и обновления.

**Методы:**

- `string GenerateAccessToken(User user)`: Генерация токена доступа для пользователя.
- `string GenerateRefreshToken()`: Генерация токена обновления.
- `ClaimsPrincipal ValidateAccessToken(string token)`: Валидация токена доступа.
- `bool ValidateRefreshToken(User user, string refreshToken)`: Валидация токена обновления для пользователя.

---

### 5. **IClientService**

**Описание:**

Сервис для управления клиентами (приложениями), которые обращаются к серверу авторизации.

**Методы:**

- `Task<Client> GetClientByIdAsync(string clientId)`: Получение клиента по идентификатору.
- `Task<bool> ValidateClientCredentialsAsync(string clientId, string clientSecret)`: Проверка учетных данных клиента.

---

### 6. **IExternalAuthenticationService**

**Описание:**

Обеспечивает интерфейс для интеграции с внешними провайдерами аутентификации (Google, Facebook и т.д.).

**Методы:**

- `Task<ExternalLoginInfo> GetExternalLoginInfoAsync(string provider)`
- `Task<bool> LinkExternalAccountAsync(User user, ExternalLoginInfo loginInfo)`

### 7. **IEventService**

**Описание:**

Интерфейс для управления событиями.

**Методы:**

- `Task PublishEventAsync<TEvent>(TEvent eventMessage)`

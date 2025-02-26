namespace Auth.Domain.Services;

/// <summary>
/// Если вы планируете использовать брокер сообщений (например, RabbitMQ) для распространения событий
/// (например, при регистрации нового пользователя), вы можете определить интерфейс для управления событиями.
/// </summary>
public interface IEventService
{
    Task PublishEventAsync<TEvent>(TEvent eventMessage);
}
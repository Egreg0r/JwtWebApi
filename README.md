docker run --name postgres -e POSTGRES_PASSWORD=123456 -d postgres -p 5432:5432
# JwtWebApi
Сделать HTTP POST эндпоинт который получает данные в json вида :
{
   userName: "имя отправителя"
   password: "пароль"
}
токен в ответ, тоже json вида:
{
   token: "тут сгенерированный токен"
}

Сообщения клиента-пользователя:
{
   loginModelUserName:  "имя отправителя",
   message:    "текст сообщение"
}

Если пришло сообщение вида:
{
    message: "history 10",
    loginModelUserName: "FirstUser"
}
проверить токен, в случае успешной проверки токена отправить отправителю 10 последних сообщений из БД

[HttpGet]
/api/LoginModels/GetResult
Осуществляет проверку авторизации. 

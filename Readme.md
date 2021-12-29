# Accounty app

## API
Deployed on [Heroku](https://accounty-yeap.herokuapp.com/)

## Documentation
Read the [Swagger documentation](https://accounty-yeap.herokuapp.com/swagger/index.html)

## TODO
* Understand why the `.HasIndex(a => new { a.BankName, a.Iban, a.Bic, a.AccountOwner })` is not enough to prevent duplicate entries
* Use immutable / record class for DTOs models
* Add more unit tests
* Use a real database (and not the InMemory)
* Improve the documentation (in source code and with Swagger)
* Improve the ErrorController with detailed Problem in Development environment.
* Add authentication
* ．．．
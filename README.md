# About

API based on [GoinGecko's public API.](https://www.coingecko.com/en/api/documentation) to get initial data for bitcoin with euro as currency. API attempts to give answer to following questions with given date range.

1. How many days is the longest downward trend?
2. Which date has the highest trading volume?
3. What are the best days to buy and sell?

### Requirements

- NET 6 SDK (Download [here](https://dotnet.microsoft.com/download/dotnet/6.0))

## Run application

```cmd
dotnet run --project WebApi
```

or

```cmd
dotnet watch run --project WebApi
```

## Use application

Use API [locally](https://localhost:5000/swagger) or hosted on [Heroku](https://bitcoin-web-api.herokuapp.com/swagger) with built-in Swagger
or with any suitable tool of your choice.

Input date format: `yyyy-MM-dd`

### Endpoints:

- /longestdownwardtrend
- /highestradingvolume
- /buyandsell

## Run tests

```cmd
dotnet test
```

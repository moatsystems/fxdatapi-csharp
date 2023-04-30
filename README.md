## Currency API C# Client

[![Build Status](https://github.com/moatsystems/currensees-csharp/actions/workflows/ci.yml/badge.svg)](https://github.com/moatsystems/currensees-csharp/actions/workflows/ci.yml)
[![NuGet version](https://badge.fury.io/nu/currensees.svg)](https://badge.fury.io/nu/currensees)

The [Currency API](https://moatsystems.com/currency-api/) client for the .NET platform.

### Usage Example

Here's a simple example of using the installed version of the Currensees package.

First, create a new .NET Console Application:

```shell
dotnet new console -n MyCurrencyApp
```

Change into the newly created directory:

```shell
cd MyCurrencyApp
```

Add the `Currensees` package from NuGet:

```shell
dotnet add package Currensees --version 0.1.0
```

Create a file called `Program.cs` in the MyCurrencyApp project with the following code:

```c#
using System;
using System.Threading.Tasks;
using Currensees;

namespace MyCurrencyApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Replace with your own credentials
            string username = "your_username"; // update with the username you receive after subscription
            string password = "your_password"; // update with the password you receive after subscription

            // Instantiate the Auth class
            var auth = new Auth();

            // Authenticate using the provided credentials
            bool isAuthenticated = await auth.Authenticate(username, password);

            if (isAuthenticated)
            {
                Console.WriteLine("Login successful");

                // Instantiate the Convert class with the authenticated Auth instance
                var converter = new Convert(auth);

                // Set currency conversion parameters
                string date = "2023_04_19";
                string baseCurrency = "GBP";
                string targetCurrency = "EUR";
                string amount = "500";

                // Perform currency conversion
                string conversionResult = await converter.ConvertCurrency(username, date, baseCurrency, targetCurrency, amount);

                if (conversionResult != null)
                {
                    Console.WriteLine($"Conversion result: {conversionResult}");
                }
                else
                {
                    Console.WriteLine("Currency conversion failed");
                }

                // Instantiate the ConvertAll class with the authenticated Auth instance
                var converterAll = new ConvertAll(auth);

                // Perform currency conversion for all available target currencies
                string conversionAllResult = await converterAll.ConvertCurrencyAll(username, date, baseCurrency, amount);

                if (conversionAllResult != null)
                {
                    Console.WriteLine($"Conversion for all target currencies result: {conversionAllResult}");
                }
                else
                {
                    Console.WriteLine("Currency conversion for all target currencies failed");
                }

                // Instantiate the DailyAverage class with the authenticated Auth instance
                var dailyAverage = new DailyAverage(auth);

                // Get daily average for the specified date
                string dailyAverageResult = await dailyAverage.GetDailyAverage("2023_04_10");

                if (dailyAverageResult != null)
                {
                    Console.WriteLine($"Daily average result: {dailyAverageResult}");
                }
                else
                {
                    Console.WriteLine("Daily average failed");
                }

                // Instantiate the WeeklyAverage class with the authenticated Auth instance
                var weeklyAverage = new WeeklyAverage(auth);

                // Get weekly average for the specified date range
                string weeklyAverageResult = await weeklyAverage.GetWeeklyAverage("2023_04_03", "2023_04_07");

                if (weeklyAverageResult != null)
                {
                    Console.WriteLine($"Weekly average result: {weeklyAverageResult}");
                }
                else
                {
                    Console.WriteLine("Weekly average failed");
                }

                // Instantiate the Currencies class with the authenticated Auth instance
                var currencies = new Currencies(auth);

                // Get all currencies
                string allCurrencies = await currencies.GetAllCurrencies(username, 19, 04, 2024);
                Console.WriteLine($"All currencies: {allCurrencies}");

                // Get currency by ID
                string currencyId = "594bffc4-d095-11ed-9e30-acde48001122";
                string currencyById = await currencies.GetCurrencyById(currencyId, username, 19, 04, 2023);
                Console.WriteLine($"Currency by ID: {currencyById}");

                // Instantiate the Historical class with the authenticated Auth instance
                var historical = new Historical(auth);

                // Get all historical data
                string allHistoricalData = await historical.GetAllHistoricalData(username, "2023_04_02", 19, 04, 2023);
                Console.WriteLine($"All historical data: {allHistoricalData}");

                // Get historical data by ID
                string dataId = "fe1ee1c4-d162-11ed-a2dc-acde48001122";
                string historicalDataById = await historical.GetHistoricalDataById(dataId, username, "2023_04_02", 02, 04, 2023);
                Console.WriteLine($"Historical data by ID: {historicalDataById}");

                // Instantiate the MarginsSpreads class with the authenticated Auth instance
                var marginsSpreads = new MarginsSpreads(auth);

                // Get all margins and spreads data
                string allMarginsSpreadsResult = await marginsSpreads.GetAllMarginsSpreads(username, 19, 04, 2023);

                if (allMarginsSpreadsResult != null)
                {
                    Console.WriteLine($"All margins and spreads result: {allMarginsSpreadsResult}");
                }
                else
                {
                    Console.WriteLine("Fetching all margins and spreads data failed");
                }

                // Get margin and spread data by UUID
                string marginSpreadByIdResult = await marginsSpreads.GetMarginSpreadById("25b51b66-e3c1-11ed-9eab-acde48001122", username, 19, 04, 2023);

                if (marginSpreadByIdResult != null)
                {
                    Console.WriteLine($"Margin and spread by UUID result: {marginSpreadByIdResult}");
                }
                else
                {
                    Console.WriteLine("Fetching margin and spread data by UUID failed");
                }

                // Instantiate the Performances class with the authenticated Auth instance
                var performances = new Performances(auth);

                // Get all performances
                string allPerformances = await performances.GetAllPerformances(username);

                if (allPerformances != null)
                {
                    Console.WriteLine($"All performances: {allPerformances}");
                }
                else
                {
                    Console.WriteLine("Getting all performances failed");
                }

                // Get performance by ID
                string performanceId = "8edd9b12-e3c2-11ed-b5bd-acde48001122";
                string performanceById = await performances.GetPerformanceById(performanceId, username);

                if (performanceById != null)
                {
                    Console.WriteLine($"Performance by ID: {performanceById}");
                }
                else
                {
                    Console.WriteLine("Getting performance by ID failed");
                }

                // Instantiate the Signals class with the authenticated Auth instance
                var signals = new Signals(auth);

                // Get all signals
                string allSignals = await signals.GetAllSignals(username);

                if (allSignals != null)
                {
                    Console.WriteLine($"All signals: {allSignals}");
                }
                else
                {
                    Console.WriteLine("Getting all signals failed");
                }

                // Get signal by ID
                string signalId = "8e694050-e3c2-11ed-b5bd-acde48001122";
                string signalById = await signals.GetSignalById(signalId, username);

                if (signalById != null)
                {
                    Console.WriteLine($"Signal by ID: {signalById}");
                }
                else
                {
                    Console.WriteLine("Getting signal by ID failed");
                }
            }
            else
            {
                Console.WriteLine("Login failed");
            }
        }
    }
}
```

Execute the code above by running:

```shell
dotnet run
```

You should see the output displaying data if the authentication is successful. 😎 🚀

### Setting up Currency API Account

Subscribe [here](https://moatsystems.com/currency-api/) for a user account.

### Using the Currency API

You can read the [API documentation](https://docs.currensees.com/) to understand what's possible with the Currency API. If you need further assistance, don't hesitate to [contact us](https://moatsystems.com/contact/).

### License

This project is licensed under the [BSD 3-Clause License](./LICENSE).

### Copyright

(c) 2020 - 2023 [Moat Systems Limited](https://moatsystems.com).
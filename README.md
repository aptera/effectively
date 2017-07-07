# Working Effectively with Legacy Code
## Kata

These kata illustrate some techinques we can use to stabilize legacy code&mdash;the code that works, DON'T TOUCH IT. For a run-down of each technique, please refer to [Michael Feathers' book](https://www.amazon.com/Working-Effectively-Legacy-Michael-Feathers/dp/0131177052).

### Extract and Override
In this kata, we have an `OrderService` that depends on a `UserService`. Your task is to add logic to the order service that rejects any order that comes in with a negative amount.

**The twist**. In order to integrate with the existing logic that checks that the current user is valid, you'll have to work around the user service. 

**Constraints**. Do not alter the order service's constructor signature--there's lots of other untested code that relies on it as-is.

### Static Cling
We need to add logging to the Database class, so that every SQL query is logged. The twist? Statics everywhere.

**Constraints**. The static calls to `Database.Query()` and `Logger.Log()` must still work, as they are in heavy use across the code base.

### Interface Indirection
Your mission, should you choose to accept it, is to get the `InvoiceService.GetInvoice` method under test to add an Invoice number generation feature. 

**The twist**. This code works just fine when it lives in a web app, but put it in a test harness, and it goes to pieces looking for a current HTTP context.

**Constraints**. Solve this one *without* using Extract and Override.

### Sprout (Breakout) Class
This code describes a dice rolling game. The task is to alter the rules so that on the turn in which the player rolls their way out of the penalty box, they advance their place by *one less* than the amount that they've rolled, rather than the full amount.

**The twist**. Game is a [God class](https://en.m.wikipedia.org/wiki/God_object).

**Constraints**. The budget does not allow time to get the whole thing under test.

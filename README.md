# DateGenerator
Simple date generator for C#
allows you to generate dates by specified days in week and DateFrequency between dates

# Usage
```c#
public DateGenerator(DateTime startDate, DateTime endDate, string[] days, string frequency)
 ```
 ---
```c#
  string[] days = new string[] { "Monday", "Wednesday", "Friday" };
  string frequency = "Weekly";
  DateTime startDate = DateTime.Now;
  DateTime endDate = startDate.AddMonths(1);

  DateGenerator dateGenerator = new DateGenerator(startDate, endDate, days, frequency);

  var result = dateGenerator.Generated;
```
---
```c#
public DateGenerator(DateTime startDate, DateTime endDate, List<DayOfWeek> days, DateFrequency frequency)
 ```
  ```c#
  string[] days = new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday };
  string frequency = DateFrequency.Weekly;
  DateTime startDate = DateTime.Now;
  DateTime endDate = startDate.AddMonths(1);

  DateGenerator dateGenerator = new DateGenerator(startDate, endDate, days, frequency);

  var result = dateGenerator.Generated;
```

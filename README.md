## Living Doc [Generate Report]

Step 1: 
$ Admin@DESKTOP-SRRVDGO E:\DotnetWorks\SpecPage01\bin\Debug\net8.0
$ dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI

Step 2:
$ Admin@DESKTOP-SRRVDGO E:\DotnetWorks\SpecPage01\bin\Debug\net8.0
$ livingdoc test-assembly SpecPage01.dll -t TestExecution.json

#### We Can also generate report at specified location-using relative or abs path

Admin@DESKTOP-SRRVDGO E:\DotnetWorks\SpecPage01\bin\Debug\net8.0
$ livingdoc test-assembly SpecPage01.dll -t TestExecution.json --output ../../../report.html

#### Generate Report For Unused Steps In Step-Definations
Admin@DESKTOP-SRRVDGO E:\DotnetWorks\SpecPage01\bin\Debug\net8.0
$ livingdoc test-assembly SpecPage01.dll --binding-assemblies "SpecPage01.dll"

### Using dotnet Command Line Tool To Run Spec Tests


### Pass Value to appSettings.json from cmd
##### error command: dotnet run --AppSettings:Environment=Staging --AppSettings:RetryCount=10 --AppSettings:Browser=Firefox etc.

## NUnit	- Options To Run Tests
   -- FullyQualifiedName
   -- Name
   -- Category
   -- Priority


1. Run using single tag
   dotnet test --filter Category=wip
   dotnet test --filter "Category=wip1 | Category=wip2"    => run either 'wip1' OR 'wip2'
   dotnet test --filter "Category=wip1 & Category=wip2"    => run either 'wip1' AND 'wip2'

2. Add details in execution on console
   $ dotnet test <project-name> --no-build -v n

3. Run Filter by "scenario title" [Note remove space in title name]
   dotnet test BookShop.AcceptanceTests --filter Name~"Authorshouldbematched"
 

## Framework Support
1. Implement specflow page object model
2. Implement specflow+livingdoc report
3. Add appSettings.json to pass and access values
4. fully dotnet compitiable to run tests from commandline

### Basic Regex Examples
1. (.*)  => match with any data
2. "[^"]*"
3. (//d+) => for multi-digits

^: Indicates the start of a line.
$: Indicates the end of a line.
.: Matches any character except a newline.
*: Matches the preceding element 0 or more times.
+: Matches the preceding element 1 or more times.
{n}: Matches exactly n occurrences of the preceding element.
[abc]: Matches any one of the characters a, b, or c.
(abc): Groups the expression inside the parentheses and treats them as a single element.


.: Any character except newline
*: 0 or more of the preceding character
{n,m}: At least n, up to m of the preceding character
(abc): Capturing group
[abc]: Character set (matching a, b, or c)
[^abc]: Negated character set (matching characters not in a, b, or c)
|: Alternation (match one of the expressions on either side of the |)

A Comprehensive List of Regex C# Match Chars and Shortcuts: From Simple to Advanced
==================
\d: A digit
\D: A non-digit character
\w: A word character (letter, digit, or underscore)
\W: A non-word character
\s: A whitespace character (space, tab, newline, etc.)
\S: A non-whitespace character
(?=...): Positive lookahead
(?!...): Negative lookahead
(?<=...): Positive lookbehind
(?<!...): Negative lookbehind
(?:...): Non-capturing group
\1, \2, etc.: Backreferences to previously captured groups


Capturing group example
==============
string input = "The color is red.";
Match match = Regex.Match(input, "The color is (red|blue)");
Console.WriteLine(match.Groups[1].Value); // Output: red

Non-capturing group example
==============
input = "The color is red.";
match = Regex.Match(input, "The color is (?:red|blue)");

Extract username from email:
=========
string input = "alice@example.com, bob@example.com, carol@example.com";
string pattern = @"([\w]+)@";

Match exect word with-in string
=========
string input = "Hooray for Regex! It's a match made in code heaven!";
string pattern = @"\bmade\b";

Match a url:
=========
string input = @"<a href=""https://www.example.com"">Example 1</a>"
string pattern = @"href=""(https?://\S+?)""";

Example of date Matching:
=========
string input = "I was born on 2001-05-15 and started my job on 2020-01-01.";
string pattern = @"(\d{4})-(\d{2})-(\d{2})";
string replacement = "$3-$2-$1";

Check if the input is a valid password
=============
string input = "Abc12345";
string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{8,14}$";

Find and output all words containing 4 or more characters
==============
string input = "Regex can do wonders for your text manipulation skills!";
string pattern = @"\b\w{4,}\b";


















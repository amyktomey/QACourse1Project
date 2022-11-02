**QA Knowledge Check**

Test plan for https://demoqa.com/books.

Demoqa has requested a new login process that improves secutiry and privacy for registered customers.  Testing covers setting up online ID's and passwords.
UserNames cannot have spaces, and must be 6 and 20 characters long.
Passwords must be 8 and 15 characters long.  Passwords are required to have as least 1 number, one capital letter, and no spaces.

Testing does not cover:  UserName or password recovery;  new registrations; profile management.  The assumption is that users have already registered as customerss, and there are no duplicate registrations in the database.

*Testing the UserName*

USE "PassW0rd" for each of these tests. This will allow ONLY the UserName to be tested.

|Test Case # | Description | Steps | Test Data | Expected Result | Actual Result | Pass/Fail |
|------|--------------------------------------|-----------------------------------------------|----------------------|-----------------------|-------------------------|--------|
|TID1|UserName already used | Click Login; click register; enter username and password | UserName = OldUser1 | UserName Declined | UserName Declined | Fail |
|TID2|UserName already used | Click Login; click register; enter username and password | UserName = NewUser1 | UserName Accepted | UserName Accepteed | Pass |
|TID3|UserName has spaces | Click Login; click register; enter username and password | UserName = No Spaces | UserName Declined | UserName Declined | Fail |
|TID4|UserName has no spaces | Click Login; click register; enter username and password | UserName = NoSpaces | UserName Accepted | UserName Accepted | Pass |
|TID5|UserName length => 6 & =< 20| Click Login; click register; enter username and password | UserName = not6 | UserName Declined | UserName Declined | Fail |
|TID6|UserName length => 6 & =< 20| Click Login; click register; enter username and password | UserName = ThisUserNameIsGreaterThan20 | UserName Declined | UserName Declined | Fail |
|TID7|UserName length => 6 & =< 20| Click Login; click register; enter username and password | UserName = PerfectUserName | UserName Accepted | UserNameAccepted | Pass |

*Testing password*

USE "PerfectUserName" for each of these tests. This will allow ONLY the Password to be tested.

|Test Case # | Description | Steps | Test Data | Expected Result | Actual Result | Pass/Fail |
|------|--------------------------------------|-----------------------------------------------|----------------------|-----------------------|-------------------------|--------|
|TPW1|Password Requires 1 Number |Click Login; click register; enter username and password | Password = PasswordOne |Password Declined | Password Declined | Fail |
|TPW2|Password Requires 1 Number | Click Login; click register; enter username and password | Passworde =Password1 | Password Accepted | Password Accepteed | Pass |
|TPW3|Password Requires 1 Capital Letter |Click Login; click register; enter username and password | Password = password1 |Password Declined | Password Declined | Fail |
|TPW4|Password Requires 1 Capital Letter | Click Login; click register; enter username and password | Password = Password1 | Password Accepted | Password Accepteed | Pass |
|TPW3|Password has spaces |Click Login; click register; enter username and password | Password =Pass word1 | Password Declined | Password Declined | Fail |
|TPW5|Password has no spaces |Click Login; click register; enter username and password |Password= Password1 | Password Accepted | Password Accepted | Pass |
|TPW6|Password length => 8 & =< 15| Click Login; click register; enter username and password | Password = Tosh0rt | Password Declined | Password Declined | Fail |
|TPW7|Password length => 8 & =< 15| Click Login; click register; enter username and password | Password = ThisPasswordIstGreaterThan20 |Passworde Declined | Password Declined | Fail |
|TPW8|Password length => 8 & =< 15| Click Login; click register; enter username and password | Password = PassW0rd |Password Accepted | Password Accepted | Pass |

Bug Report

Bugs in UserName setup:
	- When UserNames are set with the same charachers using a mix of uppercase letters, duplicates are not flagged.
		(Suggested fix: set all UserNames to uppercase so duplicates can be flagged and replaced.)
	- Special  characters invalidate a username... the only restriction sould be NO spaces.

Bugs in Password setup:
	- System rejects special characters... it should allow at least 1, but NOT require a special character.
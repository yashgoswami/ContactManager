# ContactManager
A Web API project to handle basic contact management actions. Solution follows the principles of clean architecture

# Technology Stack Used
1. .Net 6
2. Dapper
3. xUnit
4. Moq
5. FluentAssertions

# Solution Structure
Solution is segregated into following structure
- ContactManager
  - API
    - ContactManager.API (Web API)
  - Core
    - ContactManager.Application
    - ContactManager.Domain
  - Infrastructure
    - ContactManager.Persistence
  - Test
    - ContactManager.Test 

SOLID principles and clean architecture approach is used to make the solution customizable. 
Dependency injection and Custom Middleware are used to make the business logic centralized wherever applicable.
Unit Tests are writtent to test the code flow and coverage

 # Swagger UI
<img width="491" alt="image" src="https://github.com/yashgoswami/ContactManager/assets/11179792/8c5ca1a0-efbd-4cd2-9aa3-dc135e01c74f">
 
 # Further improvements
 - Logging Middleware can be used to centralize the logging mechanism and log custom properties as well
 - Further endpoints can be introduced to enhance the features of contact management.

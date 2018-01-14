Prerequisites:
1. Code is developed using Microsoft Visual Studio 2015.
2. Angular version 1.6.1 is used to develop UI code
3. Unzip the code, Click on solution file and open the project, Build the solution which will download all the required packages from nuget.
4. Once the build is successful, set iAsset.UI project as the startup project, set index.html file as the startup page and run the application. 


Description:-
- Assessment solution has various projects for UI, Api, Manager project, Utility layer and Test projects. 
- In practical applications UI code will be altogether in different solution and Backend code should be in different solution. But for this test assessment some assumptions are done and UI project and the WebApi project are in same solution as it would be easy to run the application after downloading.    
- Added Unit test cases for the WebApi, Business and Utility classes. Can add further more test cases as required.
- Business layer and Utility layer are injected at constructor level. This is done using Unity dependency injection.


UI:-

1. UI is designed and developed using Angular and Bootstrap.
2. UI related code files are included in iAsset.UI project.
3. Basic html form validations have been handled using Angular.
5. Created separate factory which talks to WebApi and gets back the response and displays on view. This data service is injected in the controller.


WebApi:-

1. Backend code is properly structured with multiple class libraries. Added separated projects for Models, Business layer, Utility layer and UnitTest cases. 
2. Added WeatherController which handles the http Api requests coming from UI.
3. Dependencies of manager classes is done at constructor level on controllers. I have used IOC framework Unity.
4. Business manager classes handles all the operations and have dependency on Utility layer.
5. Models project has model classes which can be used across all the projects.
6. Included unit test cases for controller and Business classes. Nunit framework is used for writing unit test cases and Moq is used as mocking framework.      
       
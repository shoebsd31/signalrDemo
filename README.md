# Overview
The solutions contains 3 main projects
- Server
    The server has the signalR hub. It recieves data from IOTDataSender and broadcasts it
- IOTDataSender
    This can be an IOT device which transmits IOT data. The IOTDataSender sends data to the server on the hub
- IOTDataListener
    The server saves the IOTMessage in the IOTData and transmits it to the listeners listeneing to the hub

# Unit tests (Todo) (Needed for CI CD pipeline)
For testing we can use Rhino mocks, NUnit testing frameworks
- Server:
    To check if it recieves data and it transmits data. Here the DB save can be mocked.
    A seperate unit test to check DB operations using in memory DB
    Signal R hubs can be mocked using **IHubCallerConnectionContext**
- IOTDataSender :
    - To check if it can connect to the hub. Here the hub can be mocked
    - To check if it can send data to the hub. Here the hub can be mocked
- IOTDataListener:
    - To check if it can connect to the hub. Here the hub can be mocked
    - To check if it can send data to the hub. Here the hub can be mocked

# Functional Tests (Todo) (Needed for nightly builds)
For functional testing we can use Specflow
- Before Starting :
    - Initializing the setup scenarios
- Tests
    - From sending data from Sender, till recieving it on the Listener. Checking for existance of data in database
- After tests
    - removing the dummy data stored in the database.






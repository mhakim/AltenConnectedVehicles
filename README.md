## Run API and Simulator:
##### 1- Clone the repository to local machine.
##### 2- Under web api project Apis, open Web.config file and change the connection string server name to your database server
##### 3- Under CarSimulator Project, open App.config file and change the connection string server name to your database server
##### 4- Open Package Manager window and make sure the Apis project is the startup project then select DB project and run command Updat-database
##### 5- Run instance of Web API (Apis Project) and instance of Consol application simulator (CarSimulator)

## Run Web Client:
##### 1- Open Node command window and go to AltenConnectedVehicles/Web folder
##### 2- Run npm install
##### 3- Run npm start
##### 4- In case you find that error code "self_signed_cert_in_chain", run the following command: npm config set strict-ssl false
##### 5- In case you get that error "Can't resolve @angular/cdk/" while starting the server run the following command: npm install --save @angular/material @angular/cdk, then run npm start
##### 6- Browse the Web client from URl http://localhost:4200


## Prerequisites:
##### 1- Make sure Node.js is installed on the machine.

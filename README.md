# .NET Deployments
The goal of this open source project is to allow .NET developers to deploy .NET projects. This includes Windows Services (exe), ASP.NET MVC sites, Web Api, and WCF projects. Developers are more productive when they concentrate on code and logic not on deployment tasks. 

AWS CodeDeploy will serve as our deployment engine. It's capable of deploying code to AWS Instances (servers), and also on-premises servers. 

Powershell will be our scripting tool responsible to create Windows Services and IIS sites.

This project is built against .NET Core 2. .NET Core is cross-platform and can run on Windows, Linux, and Mac OS.

# Setup AWS Credentials (Official links)

 - [Configuring the AWS CLI](http://docs.aws.amazon.com/cli/latest/userguide/cli-chap-getting-started.html)
 - [Set up AWS Credentials and Region for Development](http://docs.aws.amazon.com/sdk-for-java/v1/developer-guide/setup-credentials.html)

# Contributing
To get started with this project, you will need to [install .NET Core.](https://www.microsoft.com/net/download/core) After installing .NET Core, you can use any text editor to make your changes. I highly recommend using [Visual Studio Code](https://code.visualstudio.com/download).

You also need to [install AWS CLI tool](http://docs.aws.amazon.com/cli/latest/userguide/installing.html) and [setup a profile](http://docs.aws.amazon.com/cli/latest/userguide/cli-chap-getting-started.html) called "dotnetdeployments-profile".

Now you can go ahead and clone the repo:
```
$ git clone https://github.com/agileraymond/DotNetDeployments.git
```
Now you are ready to add a new feature or fix a bug. Make your changes locally and when you are ready for a code review submit a pull request.


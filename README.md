# ANABI Platform - API

[![GitHub contributors](https://img.shields.io/github/contributors/code4romania/anabi-gestiune-api.svg?style=for-the-badge)]() [![GitHub last commit](https://img.shields.io/github/last-commit/code4romania/anabi-gestiune-api.svg?style=for-the-badge)]() [![License: MPL 2.0](https://img.shields.io/badge/license-MPL%202.0-brightgreen.svg?style=for-the-badge)](https://opensource.org/licenses/MPL-2.0)

Code 4 Romania is currently developing a platform centralizing all criminal assets seized in Romania, their net worth and location for the National Agency for the Management of Seized Assets. Goods are often seized as part of corruption-related or other criminal activities. Romania does not have an manageable digital inventory of every confiscated good, therefore the agency is struggling with managing the confiscation process, allocating space in warehouses throughout the country, protecting them, evaluating them and finally reselling or repurposing those goods. The goal is to map all seized assets so that, first and foremost, citizens know what is going on with these assets. Secondly, the National Agency will also use the platform to administer and re-direct these assets. The platform will therefore also make the process of administering seized assets more transparent. The Agency has a plan and process in place for re-utilizing or re-selling goods. The money made from re-selling goods will be turned into a financing grant for NGOs, and other goods (such as buildings) will be also given as working space for non-profits, for example.

[Contributing](#contributing) | [Built with](#built-with) | [Repos and projects](#repos-and-projects) | [Deployment](#deployment) | [Feedback](#feedback) | [License](#license) | [About Code4Ro](#about-code4ro)

## Contributing

This project is built by amazing volunteers and you can be one of them! Here's a list of ways in [which you can contribute to this project](.github/CONTRIBUTING.MD).

## Built With

.Net Core 1.1 ^

SQL Server Express

Visual Studio Community Edition (Free/Multiplatform)

Swagger

## Deployment

1. install .NetCore (Open Source/Free/Multiplatform) from [here](https://www.microsoft.com/net/core#windows)

2. run the following command from the console, from inside the Anabi folder:
    ```sh
    anabi-gestiune-api.git\Anabi> dotnet restore
    ```
  
3. run the following command from the console, from inside the Anabi folder:
    ```sh
    anabi-gestiune-api.git\Anabi> dotnet run
    ```
  
4. browse to indicated address: e.g. <http://localhost:5000/swagger>

## Repos and projects

Related projects:
* repo for the client - https://github.com/code4romania/anabi-gestiune-client

## Feedback

* Request a new feature on GitHub.
* Vote for popular feature requests.
* File a bug in GitHub Issues.
* Email us with other feedback contact@code4.ro

## License

This project is licensed under the MPL 2.0 License - see the [LICENSE](LICENSE) file for details

## About Code4Ro

Started in 2016, Code for Romania is a civic tech NGO, official member of the Code for All network. We have a community of over 500 volunteers (developers, ux/ui, communications, data scientists, graphic designers, devops, it security and more) who work pro-bono for developing digital solutions to solve social problems. #techforsocialgood. If you want to learn more details about our projects [visit our site](https://www.code4.ro/en/) or if you want to talk to one of our staff members, please e-mail us at contact@code4.ro.

Last, but not least, we rely on donations to ensure the infrastructure, logistics and management of our community that is widely spread across 11 timezones, coding for social change to make Romania and the world a better place. If you want to support us, [you can do it here](https://code4.ro/en/donate/).

# MeetManage

MeetManage is a web-based application built using ASP.NET MVC to help users manage and schedule meetings effectively. The application provides functionalities for managing users, events, and now, invitations.

## Features

- **User Management**: Allows users to register, login, and manage their profiles.
- **Event Scheduling**: Create, update, and manage meetings.
- **Invitation Management**: Users can send and receive invitations for events, track responses, and take necessary actions.
- **Dashboard**: Overview of upcoming meetings and invitations.
- **Authentication & Authorization**: Secure access with role-based permissions.

## New Feature: Invitations

A new feature has been added to manage event invitations. Users can now receive, track, and respond to invitations.

### Invitations Table Structure

| Column | Description |
|--------|-------------|
| Id | Primary Key (Unique Identifier) |
| DateReceived | Date/Time the invitation was received |
| From | Sender of the invitation |
| Item | Short description of the invitation |
| EventDate | Date of the event |
| EventPlace | Location of the event |
| EventTime | Time of the event |
| Comments | Additional notes or instructions |
| Decision | Invitation status (Accepted, Declined) |
| DaysBeforeApology | Number of days before a cancellation or apology is needed |
| Action | Required action (Confirm attendance, Respond with apology) |

## Installation Guide

### Prerequisites

- Visual Studio (2019 or later)
- .NET Framework 4.7+ or .NET Core (if applicable)
- SQL Server (LocalDB or Full SQL Server)
- Entity Framework

### Setup Instructions

1. Clone the repository:
   ```sh
   git clone https://github.com/SirTebz/MeetManage.git
   cd MeetManage
   ```
2. Open the project in Visual Studio.
3. Restore dependencies:
   ```sh
   nuget restore
   ```
4. Update the database:
   ```sh
   Enable-Migrations
   Add-Migration InitialCreate
   Update-Database
   ```
5. Run the project:
   - Press `F5` in Visual Studio or use the .NET CLI.

## Usage

- Register and log in to access the dashboard.
- Create and manage meetings.
- Send and respond to invitations.
- Track upcoming events and invitation statuses.

## Contributing

Contributions are welcome! Feel free to fork the repository and submit pull requests.

## License

This project is licensed under the MIT License.

## Contact

For any queries, reach out to [Your Contact Email or GitHub Issues].


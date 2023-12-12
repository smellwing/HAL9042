
# HAL9042 Chat Interface

## Overview

HAL9042 is a sophisticated chat interface designed to interact with ChatGPT. It employs a command pattern to process user inputs and ChatGPT responses, providing a seamless and interactive chat experience.

### Features
- **Interactive Chat Interface**: Communicate with ChatGPT through a console-based interface.
- **Command Handling**: Uses the Command design pattern to handle chat and CLI commands.
- **Chat History Tracking**: Maintains a log of the chat history for reference but still do nothing.
- **Customizable Responses**: Supports different modes of operation through command line arguments: Ask like chat or yus ask for commands!

## Getting Started

### Prerequisites
- .NET Core 3.1 or higher.
- Basic understanding of C# and command line operations.

### Installation
1. Clone the repository:
   ```sh
   git clone [repository-url]
   ```
2. Navigate to the project directory and build the project:
   ```sh
   dotnet build
   ```

### Running HAL9042
To start HAL9042, use the following command:
```sh
dotnet run
```

## Usage

### Basic Operation
Start the program and interact with the ChatGPT interface through the console.

### Command Line Arguments
- `-a [input]`: Ask any question and you get the answer from ChatGPT!
- `-c [input]`: Ask for any CLI command and you get it!

### Exiting the Program
Type `/exit` in the chat interface to terminate the session.

## Code Structure

### Key Components
- `ChatGPTControl`: Handles interactions with ChatGPT.
- `CLIControl`: Manages command line interface operations.
- `Invoker`: Executes the commands.
- `HandleSendMessageCommand`: Command pattern implementation for sending messages.

### Main Loop
The `while` loop in the `Main` method facilitates continuous interaction until the `/exit` command is triggered.

## Contribution

Contributions are welcome. Please fork the repository and submit pull requests with your changes.

## License

This project is licensed under the [MIT License](LICENSE.md).

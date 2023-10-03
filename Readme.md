# README.md - Chat con ChatGPT

## Introducción

Este documento describe el funcionamiento y los detalles técnicos de un programa de chat interactivo que utiliza el modelo ChatGPT para generar respuestas basadas en la entrada del usuario. Este programa ha sido diseñado utilizando el patrón de diseño Command para gestionar las interacciones con el modelo ChatGPT.

## Requerimientos

- API Key de ChatGPT. Esta clave debe ser introducida en el campo "YOUR_API_KEY".
- Librerías:
  - Whetstone.ChatGPT
  - Whetstone.ChatGPT.Models

## Funcionamiento General

Cuando el usuario ejecuta el programa, se le da la bienvenida y se le indica que puede escribir `/exit` para salir del chat. A continuación, el programa entra en un bucle donde espera la entrada del usuario. Una vez que el usuario proporciona una entrada, el programa se comunica con el modelo ChatGPT utilizando el patrón Command para obtener una respuesta y, posteriormente, la muestra al usuario.

## Detalles Técnicos

### Clases y Métodos:

- **Program**: Clase principal del programa.
  - **Main ( string[] args )**: Método principal del programa. Maneja la interacción del usuario y se comunica con el modelo ChatGPT para obtener respuestas utilizando el patrón Command.
  
- **ICommand**: Define una interfaz para ejecutar una operación relacionada con el chat.
  
- **SendMessageCommand**: Implementa `ICommand` para enviar un mensaje a ChatGPT.
  
- **ChatInvoker**: Pide al command que ejecute la solicitud.

### Interacción con el Modelo ChatGPT:

Se utiliza el cliente `IChatGPTClient` para comunicarse con el modelo. Para ello, se necesita una API Key que debe ser introducida en el campo "YOUR_API_KEY".

El objeto `ChatGPTChatCompletionRequest` se utiliza para enviar la solicitud al modelo. En este programa, se ha establecido el modelo a `ChatGPT35Models.Turbo` y se ha limitado el número máximo de tokens de respuesta a 100.

### Salida del Programa:

El programa registra la historia de chat en una lista llamada `chatHistory`. Esta lista almacena tanto las entradas del usuario como las respuestas de ChatGPT.

## Uso:

1. Ejecute el programa.
2. Introduzca cualquier texto para chatear con ChatGPT.
3. Para salir del chat, escriba `/exit`.

---

**Nota 1**: Asegúrese de tener una API Key válida de ChatGPT para que el programa funcione correctamente.

**Nota 2**: Este README.md fue generado por ChatGPT.

**Nota 3**: Este programa utiliza el patrón de diseño Command para gestionar las interacciones con el modelo ChatGPT.

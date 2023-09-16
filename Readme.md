# README.md - Chat con ChatGPT

## Introducci�n

Este documento describe el funcionamiento y los detalles t�cnicos de un programa de chat interactivo que utiliza el modelo ChatGPT para generar respuestas basadas en la entrada del usuario.

## Requerimientos

- API Key de ChatGPT. Esta clave debe ser introducida en el campo "YOUR_API_KEY".
- Librer�as:
  - Whetstone.ChatGPT
  - Whetstone.ChatGPT.Models

## Funcionamiento General

Cuando el usuario ejecuta el programa, se le da la bienvenida y se le indica que puede escribir `/exit` para salir del chat. A continuaci�n, el programa entra en un bucle donde espera la entrada del usuario. Una vez que el usuario proporciona una entrada, el programa se comunica con el modelo ChatGPT para obtener una respuesta y, posteriormente, la muestra al usuario.

## Detalles T�cnicos

### Clases y M�todos:

- **Program**: Clase principal del programa.
  - **Main ( string[] args )**: M�todo principal del programa. Maneja la interacci�n del usuario y se comunica con el modelo ChatGPT para obtener respuestas.

### Interacci�n con el Modelo ChatGPT:

Se utiliza el cliente `IChatGPTClient` para comunicarse con el modelo. Para ello, se necesita una API Key que debe ser introducida en el campo "YOUR_API_KEY".

El objeto `ChatGPTChatCompletionRequest` se utiliza para enviar la solicitud al modelo. En este programa, se ha establecido el modelo a `ChatGPT35Models.Turbo` y se ha limitado el n�mero m�ximo de tokens de respuesta a 100.

### Salida del Programa:

El programa registra la historia de chat en una lista llamada `chatHistory`. Esta lista almacena tanto las entradas del usuario como las respuestas de ChatGPT.

## Uso:

1. Ejecute el programa.
2. Introduzca cualquier texto para chatear con ChatGPT.
3. Para salir del chat, escriba `/exit`.

---

**Nota 1**: Aseg�rese de tener una API Key v�lida de ChatGPT para que el programa funcione correctamente.

**Nota 2**: Este README.md fue generado por ChatGPT.

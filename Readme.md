# README.md - Chat con ChatGPT

## Introducción

Este documento describe el funcionamiento y los detalles técnicos de un programa de chat interactivo que utiliza el modelo ChatGPT para generar respuestas basadas en la entrada del usuario a través del control `ChatGPTControl` de `HAL9042.Controls`.

## Requerimientos

- **API Key** de ChatGPT. Esta clave debe ser introducida en el archivo de configuración bajo la llave "OpenAIAPIKey".
- **Librerías**:
  - Whetstone.ChatGPT
  - Whetstone.ChatGPT.Models
  - System.Configuration
  - HAL9042.Controls

## Funcionamiento General

Al ejecutar el programa, el usuario es recibido con un mensaje de bienvenida y se le indica que puede escribir `/exit` para salir del chat. Posteriormente, el programa entra en un bucle donde aguarda la entrada del usuario. Al recibir una entrada, se comunica con ChatGPT para obtener una respuesta y la muestra en consola.

## Detalles Técnicos

### Clases y Métodos:

- **Program**: Clase principal que maneja la interacción con el usuario.
  - **Main ( string[] args )**: Método principal del programa. Maneja la interacción del usuario y se comunica con ChatGPT a través del control `ChatGPTControl`.
  
- **ChatGPTControl (HAL9042.Controls)**: Controlador para simplificar la interacción con el modelo ChatGPT.
  - **Ask (string usrAsk)**: Prepara la solicitud para ChatGPT basándose en la entrada del usuario.
  - **Complete()**: Realiza la solicitud a ChatGPT y devuelve una respuesta.

### Interacción con el Modelo ChatGPT:

Se utiliza el control `ChatGPTControl` para la comunicación con ChatGPT. Dicho control emplea el cliente `IChatGPTClient` para esta tarea. La clave API se obtiene desde la configuración del proyecto.

### Salida del Programa:

La interacción con el chat (preguntas del usuario y respuestas de ChatGPT) se almacena en una lista llamada `chatHistory`.

## Uso:

1. Asegúrese de introducir su API Key de ChatGPT en el archivo de configuración bajo la llave "OpenAIAPIKey".
2. Ejecute el programa.
3. Introduzca cualquier texto para iniciar la conversación con ChatGPT.
4. Escriba `/exit` para finalizar el chat.

---

**Nota**: Este README.md fue generado por ChatGPT.

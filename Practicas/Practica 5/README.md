# Codigo Practica 5

``` /*
  Programa: Práctica 5: Conexión a Raspberry y ChatGPT
  Autores:
    - López Machado Óscar Roberto - 21211978
    - Morales Hernández José Luis - 21212001
    - Torres Equihua Victor Manuel - 21212058
    - Van Pratt González Ricardo Adolfo - 21212581
  Fecha: 21 de mayo de 2024

  Descripción:
  Se conecta a ChatGPT con una raspberry

  Licencia: [Tipo de licencia]
*/

#include <WiFi.h>
#include <WiFiClientSecure.h>
#include <HTTPClient.h>
#include <ArduinoJson.h>
#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>

// Credenciales de WiFi
const char* ssid = "TecNM-ITT-Docentes";             
const char* password = "Person@L2024!";

// API Key y endpoint de OpenAI (usando la clave de API proporcionada)
const char* api_key = "sk-proj-Yyfx5hCGu2m6IAYyN22IT3BlbkFJyPbzt1XRLacTHUBD1uCa";
const char* endpoint = "https://api.openai.com/v1/chat/completions";

// Configuración del Display OLED
#define SCREEN_WIDTH 128
#define SCREEN_HEIGHT 64
#define OLED_RESET -1
#define SCREEN_ADDRESS 0x3C // Usualmente la dirección I2C para SSD1306 es 0x3C
Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, OLED_RESET);

// LED interno
const int ledPin = LED_BUILTIN;

bool displayConnected = false;

void setup() {
  Serial.begin(115200);
  pinMode(ledPin, OUTPUT);

  // Inicialización de OLED
  if(display.begin(SSD1306_SWITCHCAPVCC, SCREEN_ADDRESS)) {
    displayConnected = true;
    display.clearDisplay();
    display.setTextSize(1);
    display.setTextColor(SSD1306_WHITE);
    display.setCursor(0,0);
    display.display();
    display.println("Display conectado!");
    display.display();
  } else {
    Serial.println(F("Failed to initialize the display!"));
  }

  // Conectar a WiFi
  Serial.print("Conectando a ");
  Serial.println(ssid);
  if (displayConnected) {
    display.print("Conectando a ");
    display.println(ssid);
    display.display();
  }

  WiFi.begin(ssid, password);
  int attempts = 0;
  while (WiFi.status() != WL_CONNECTED && attempts < 20) {
    delay(500);
    Serial.print(".");
    if (displayConnected) {
      display.print(".");
      display.display();
    }
    attempts++;
  }

  if(WiFi.status() == WL_CONNECTED) {
    Serial.println("\nConectado a WiFi");
    if (displayConnected) {
      display.println("\nConectado a WiFi");
      display.display();
    }
  } else {
    Serial.println("\nError de conexión WiFi");
    if (displayConnected) {
      display.println("\nError de conexión WiFi");
      display.display();
    }
    return;
  }
}

void sendMessageToChatGPT(String messageContent) {
  if (WiFi.status() == WL_CONNECTED) {
    WiFiClientSecure client;
    client.setInsecure(); // Utilizar esta opción para pruebas, en producción utiliza verificación de certificado

    HTTPClient http;
    http.begin(client, endpoint);
    http.addHeader("Content-Type", "application/json");
    http.addHeader("Authorization", String("Bearer ") + api_key);

    // Crear payload JSON
    StaticJsonDocument<1024> doc;
    doc["model"] = "gpt-3.5-turbo";
    JsonArray messages = doc.createNestedArray("messages");
    JsonObject message = messages.createNestedObject();
    message["role"] = "user";
    message["content"] = messageContent;

    String requestBody;
    serializeJson(doc, requestBody);

    Serial.println("Request Body:");
    Serial.println(requestBody);

    // Enviar solicitud
    int httpResponseCode = http.POST(requestBody);

    if (httpResponseCode > 0) {
      String response = http.getString();
      Serial.println(httpResponseCode);
      Serial.println(response);

      // Procesar respuesta y parpadear LED
      StaticJsonDocument<2048> responseDoc;
      DeserializationError error = deserializeJson(responseDoc, response);
      if (!error) {
        const char* content = responseDoc["choices"][0]["message"]["content"];
        Serial.println("Respuesta de ChatGPT:");
        Serial.println(content);
        
        if (displayConnected) {
          // Mostrar respuesta en el display OLED
          display.clearDisplay();
          display.setCursor(0, 0);
          display.print("Respuesta:");
          display.setCursor(0, 10);
          display.print(content);
          display.display();
        }

        // Parpadear LED por cada carácter recibido
        for (size_t i = 0; i < strlen(content); i++) {
          digitalWrite(ledPin, HIGH);
          delay(200);
          digitalWrite(ledPin, LOW);
          delay(200);
        }
      } else {
        Serial.println("Error al parsear la respuesta JSON");
      }
      
    } else {
      Serial.print("Error en la solicitud: ");
      Serial.println(httpResponseCode);
      Serial.println(http.errorToString(httpResponseCode)); // Añadir mensaje de error
    }

    http.end();
  } else {
    Serial.println("WiFi no está conectado");
  }
}

void loop() {
  // Leer entrada del monitor serial
  if (Serial.available() > 0) {
    String messageContent = Serial.readStringUntil('\n');
    Serial.println("Mensaje recibido: " + messageContent);
    sendMessageToChatGPT(messageContent);
  }
} ```

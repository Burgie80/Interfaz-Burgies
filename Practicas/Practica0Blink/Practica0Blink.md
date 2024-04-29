# Práctica 0: Blink
```
/*
  Programa: Práctica 0: Blink
  Autores: 
    - [Apellidos] [Nombre] - [Número de control]
    - [Apellidos] [Nombre] - [Número de control]
    - [Apellidos] [Nombre] - [Número de control]
    - Van Pratt González Ricardo Adolfo - 21212581
  Fecha: 29 de abril de 2024

  Descripción:
  Este programa provoca que el foco LED dentro de la Raspberry parpadee con intervalos de 1 segundo.

  Licencia: [Tipo de licencia]
*/

#include <Arduino.h>

void setup() {
  // Se inicializa el pin digital como salida
  pinMode(LED_BUILTIN, OUTPUT);
}

void loop() {
  // Enciende la luz del foco integrado dentro de la Raspberry Pi Pico W
  digitalWrite(LED_BUILTIN, HIGH);
  // Espera 1000 ms
  delay(500);
  // Apaga la luz del foco integrado dentro de la Raspberry Pi Pico W
  digitalWrite(LED_BUILTIN, LOW);
  // Espera 1000 ms
  delay(500);
}
```

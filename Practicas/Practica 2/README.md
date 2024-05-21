# Práctica 2: Pantalla OLED
## Código
```
/*
  Programa: Práctica 2: Pantalla OLED
  Autores: 
    - López Machado Óscar Roberto - [Número de control]
    - Morales Calvo Ángel Omar - [Número de control]
    - Torres Equihua Victor Manuel - [Número de control]
    - Van Pratt González Ricardo Adolfo - 21212581
  Fecha: 09 de mayo de 2024

  Descripción:
  Este programa permite desplegar un mensaje en la pantalla de una OLED conectada a la Raspberry Pi Pico W

  Licencia: [Tipo de licencia]
*/
#include <Wire.h>
#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>

#define SCREEN_WIDTH 128
#define SCREEN_HEIGHT 64

Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, -1);

void setup() {
  // put your setup code here, to run once:
  Serial1.begin(115200);
  //Serial1.println("Hello, Raspberry Pi Pico!");
  if(!display.begin(SSD1306_SWITCHCAPVCC, 0x3C)){
    Serial.println(F("SSD1306 ha fallado"));
    for(;;);
  }
}

void loop() {
  // put your main code here, to run repeatedly:
  delay(2000); // this speeds up the simulation
  display.clearDisplay();
  display.setTextSize(1);
  display.setTextColor(WHITE);
  display.setCursor(0,0);

  display.println("Hola mundo :) 8===D");
  display.display();
}
```
## Foto del programa
![1c1dacc1-c3f8-446a-8d20-ee8d89c3c8d0](https://github.com/Burgie80/Interfaz-Burgies/assets/147211017/d555876c-37a0-4981-81a6-5330d05ab512)

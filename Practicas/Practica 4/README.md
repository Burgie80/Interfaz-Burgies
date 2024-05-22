# Codigo Practica 4
 
 ```/*
Programa: Práctica 4: Conexión a Raspberry mediante bluetooth
  Autores:
    - López Machado Óscar Roberto - 21211978
    - Morales Hernández José Luis - 21212001
    - Torres Equihua Victor Manuel - 21212058
    - Van Pratt González Ricardo Adolfo - 21212581
  Fecha: 21 de mayo de 2024

  Descripción:
  Se realiza una conexión con la raspberry a través de bluetooth para prender un foco LED

  Licencia: [Tipo de licencia]
*/

#include <BTstackLib.h>
#include <SPI.h>

static char characteristic_data = 'H';

void setup(void)
{

    Serial.begin(9600);
    pinMode(LED_BUILTIN, OUTPUT);

    // set callbacks
    BTstack.setBLEDeviceConnectedCallback(deviceConnectedCallback);
    BTstack.setBLEDeviceDisconnectedCallback(deviceDisconnectedCallback);
    BTstack.setGATTCharacteristicRead(gattReadCallback);
    BTstack.setGATTCharacteristicWrite(gattWriteCallback);

    // setup GATT Database
    BTstack.addGATTService(new UUID("B8E06067-62AD-41BA-9231-206AE80AB551"));
    BTstack.addGATTCharacteristic(new UUID("f897177b-aee8-4767-8ecc-cc694fd5fcef"), ATT_PROPERTY_READ, "This is a String!");
    BTstack.addGATTCharacteristicDynamic(new UUID("f897177b-aee8-4767-8ecc-cc694fd5fce0"), ATT_PROPERTY_READ | ATT_PROPERTY_WRITE | ATT_PROPERTY_NOTIFY, 0);

    // startup Bluetooth and activate advertisements
    BTstack.setup();
    BTstack.startAdvertising();
}

void loop(void)
{
    BTstack.loop();
}

void deviceConnectedCallback(BLEStatus status, BLEDevice *device)
{
    (void)device;
    switch (status)
    {
    case BLE_STATUS_OK:
        Serial.println("Device connected!");
        break;
    default:
        break;
    }
}

void deviceDisconnectedCallback(BLEDevice *device)
{
    (void)device;
    Serial.println("Disconnected.");
}

uint16_t gattReadCallback(uint16_t value_handle, uint8_t *buffer, uint16_t buffer_size)
{
    (void)value_handle;
    (void)buffer_size;
    if (buffer)
    {
        Serial.print("gattReadCallback, value: ");
        Serial.println(characteristic_data, HEX);
        buffer[0] = characteristic_data;

        if (characteristic_data == '1')
            digitalWrite(LED_BUILTIN, HIGH); // turn the LED on (HIGH is the voltage level)
        else if (characteristic_data == '0')
            digitalWrite(LED_BUILTIN, LOW); // turn the LED off by making the voltage LOW
    }
    return 1;
}

int gattWriteCallback(uint16_t value_handle, uint8_t *buffer, uint16_t size)
{
    (void)value_handle;
    (void)size;
    characteristic_data = buffer[0];

    if (characteristic_data == '1')
        digitalWrite(LED_BUILTIN, HIGH); // turn the LED on (HIGH is the voltage level)
    else if (characteristic_data == '0')
        digitalWrite(LED_BUILTIN, LOW); // turn the LED off by making the voltage LOW

    Serial.print("gattWriteCallback , value ");
    Serial.println(characteristic_data, HEX);
    return 0;
} ```

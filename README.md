# FRIOCALC

FRIOCALC es una calculadora web para seleccionar equipos de refrigeracion para cuartos frios a partir de medidas, volumen y tipo de uso. El objetivo del proyecto es convertir una tabla tecnica de seleccion en una herramienta rapida, visual y facil de usar para ventas, cotizaciones y validaciones iniciales.

## Demo en produccion

La aplicacion esta desplegada en Vercel:

[https://friocalc.vercel.app/](https://friocalc.vercel.app/)

## Que hace

- Calcula el volumen del cuarto frio usando largo, ancho y altura.
- Permite ingresar el volumen directamente cuando ya se conoce.
- Alterna entre seleccion para enfriamiento y congelacion.
- Recomienda capacidad en HP y BTU segun la tabla tecnica integrada.
- Redondea hacia el volumen inmediato superior disponible para mantener una seleccion conservadora.
- Incluye experiencia PWA para instalar desde el navegador en dispositivos moviles.
- Incluye version ejecutable para Windows.

## Stack

- HTML, CSS y JavaScript vanilla.
- PWA con `manifest.webmanifest` y `sw.js`.
- Deploy estatico en Vercel.
- Empaquetado Windows con archivos nativos en `Native/`.

## Estructura principal

```text
FRIOCALC/
|-- index.html              # Interfaz principal
|-- styles.css              # Estilos de la aplicacion
|-- app.js                  # Logica de calculo y seleccion
|-- manifest.webmanifest    # Configuracion PWA
|-- sw.js                   # Service worker
|-- vercel.json             # Configuracion para Vercel
|-- FRIOCALC_WINDOWS.exe    # Ejecutable para Windows
|-- Abrir FRIOCALC.bat      # Lanzador local para Windows
`-- Native/                 # Recursos y codigo nativo
```

## Lanzamiento local

Este proyecto no requiere instalacion de dependencias para correr la version web.

### Opcion 1: abrir directamente

1. Clona el repositorio.
2. Abre `index.html` en tu navegador.
3. Ingresa las medidas o el volumen del cuarto frio.

### Opcion 2: usar un servidor local

Esta opcion es recomendable para probar la PWA, el manifest y el service worker.

Con Python:

```bash
python -m http.server 8000
```

Luego abre:

```text
http://localhost:8000
```

Con Node.js:

```bash
npx serve .
```

Luego abre la URL local que indique la terminal.

### Opcion 3: Windows

En Windows tambien puedes iniciar la version local con:

```text
FRIOCALC_WINDOWS.exe
```

o con:

```text
Abrir FRIOCALC.bat
```

## Deploy

El deploy de produccion esta preparado para Vercel. Para publicar desde una cuenta propia:

1. Importa el repositorio en Vercel.
2. Usa la configuracion por defecto para proyecto estatico.
3. Vercel servira `index.html` como entrada principal.

El archivo `vercel.json` define headers especificos para `sw.js` y `manifest.webmanifest`.

## Nota tecnica

La tabla de capacidades vive dentro de `app.js` como datos estructurados. La seleccion busca el primer volumen compatible igual o superior al volumen calculado o ingresado por el usuario.

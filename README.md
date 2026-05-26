# FRIOCALC

Calculadora local para seleccionar equipo de cuarto frio a partir de medidas o volumen directo.

## Uso

1. Abre `FRIOCALC_WINDOWS.exe` en Windows. Tambien puedes usar `Abrir FRIOCALC.bat`.
2. Ingresa largo, ancho y altura, o cambia a modo volumen.
3. Elige enfriamiento o congelacion.

La seleccion usa la tabla del libro `Seleccion cuarto frio.xlsx` y redondea siempre hacia el volumen inmediato superior disponible.

## Version web / Android

La carpeta tambien contiene una PWA lista para Vercel:

- `index.html`
- `styles.css`
- `app.js`
- `manifest.webmanifest`
- `sw.js`
- `vercel.json`

En Android se abre desde Chrome y se instala con `Agregar a pantalla de inicio`.

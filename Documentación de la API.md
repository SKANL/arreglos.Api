## Documentación de la API

Este documento describe, en lenguaje claro y accesible, los ejercicios expuestos por la API de `arreglos.Api`.
Está pensado para personas no técnicas: evita referencias al código y explica qué esperar, qué comprobar y cómo se manejan errores comunes.

### Cómo leer esta documentación

- Para cada ejercicio encontrarás: una descripción del problema, un análisis con Entradas/Proceso/Salida, una explicación paso a paso del funcionamiento (sin referencias técnicas), y las validaciones y mensajes de error que pueden verse en pruebas.
- No incluye ejemplos técnicos ni fragmentos de código. Si necesitas ejemplos para probar, pídemelos y los preparo separados.

---

## Ejercicio 1 — Contador de ceros por fila

Descripción del problema

Contar cuántos ceros hay en cada fila de una tabla de números (matriz). El resultado es un listado con la cantidad de ceros encontrados en cada fila.

Análisis (Entradas / Proceso / Salida)

- Entradas: Una matriz (lista de filas) donde cada fila contiene números enteros.
- Proceso: Revisar cada fila y contar los elementos que son exactamente cero.
- Salida: Un arreglo (lista) con un número por cada fila que indica cuántos ceros contiene esa fila.

Funcionamiento paso a paso (explicación amigable)

1. Se recibe la tabla de números.
2. Para cada fila de la tabla, se revisan sus números uno por uno.
3. Se mantiene un conteo por fila de los números que son cero.
4. Al terminar, se devuelve una lista con los conteos, en el mismo orden de las filas.

Validaciones y mensajes de error

- Si la tabla completa falta o está vacía: mensaje "hay datos faltantes".
- Si alguna fila es nula o falta: mensaje "hay datos faltantes" indicando la fila afectada.
- Si los valores no son números (por ejemplo texto en lugar de números): mensaje "Introducir sólo números".

---

## Ejercicio 2 — Verificar si es cuadrado mágico

Descripción del problema

Determinar si una tabla cuadrada de números forma un "cuadrado mágico": todas sus filas, columnas y las dos diagonales suman lo mismo. Si lo es, también se informa la suma común (constante mágica).

Análisis (Entradas / Proceso / Salida)

- Entradas: Una matriz cuadrada (mismo número de filas y columnas) con números positivos.
- Proceso: Comparar las sumas de todas las filas, todas las columnas y las dos diagonales para verificar que son iguales.
- Salida: Un indicador verdadero/falso que dice si es cuadrado mágico y, si corresponde, la suma común.

Funcionamiento paso a paso (explicación amigable)

1. Se comprueba que la tabla sea efectivamente cuadrada (misma cantidad de filas y columnas).
2. Se revisan los números para confirmar que sean valores válidos (positivos).
3. Se calcula la suma de la primera fila y se usa como referencia.
4. Se compara esa referencia con la suma de cada fila, cada columna y ambas diagonales.
5. Si todas las sumas coinciden, se informa que es un cuadrado mágico y se devuelve la suma.

Validaciones y mensajes de error

- Si la matriz falta, está vacía o no es cuadrada: mensaje "hay datos faltantes" o "La matriz debe ser cuadrada" según el caso.
- Si hay valores no numéricos: mensaje "Introducir sólo números".
- Si existen números no positivos cuando se requieren positivos: mensaje "Los valores deben ser positivos".

---

## Ejercicio 3 — Operaciones entre dos matrices

Descripción del problema

Realizar suma, resta, multiplicación elemento a elemento y división (elemento a elemento) entre dos tablas de números de las mismas dimensiones.

Análisis (Entradas / Proceso / Salida)

- Entradas: Dos matrices con la misma cantidad de filas y columnas, formadas por números enteros.
- Proceso: Para cada posición (fila, columna) se calcula la suma, la resta, el producto y la división entre los números correspondientes de ambas matrices.
- Salida: Cuatro matrices que contienen, respectivamente, los resultados de la suma, la resta, el producto y la división.

Funcionamiento paso a paso (explicación amigable)

1. Se verifica que ambas tablas estén presentes y que tengan las mismas dimensiones.
2. Se recorre cada posición de las tablas simultáneamente.
3. Para cada par de números en la misma posición se calcula la suma, la resta, el producto y la división.
4. Si la segunda tabla tiene un cero en la posición de división, el resultado de esa división se marca como "infinito" en la salida (por no poder dividir por cero).
5. Se devuelven las cuatro tablas con los resultados.

Validaciones y mensajes de error

- Si alguna de las matrices falta o está vacía: mensaje "hay datos faltantes".
- Si las dimensiones no coinciden: mensaje "Dimensiones incompatibles".
- Si hay valores no numéricos: mensaje "Introducir sólo números".
- Si ocurre división entre cero en una posición, la respuesta para esa celda será tratada como "infinito" (no se detiene el proceso completo).

---

## Ejercicio 4 — Generar matriz identidad

Descripción del problema

Generar una tabla cuadrada de tamaño N donde la diagonal principal tiene 1 y el resto de los elementos son 0. Esto se conoce como matriz identidad.

Análisis (Entradas / Proceso / Salida)

- Entradas: Un número entero positivo N (tamaño de la matriz).
- Proceso: Crear una matriz N x N y colocar 1 en cada posición (i,i) de la diagonal principal; el resto quedan en 0.
- Salida: La matriz identidad N x N.

Funcionamiento paso a paso (explicación amigable)

1. Se solicita el tamaño deseado para la matriz.
2. Se crea una tabla con N filas y N columnas.
3. En cada fila se coloca un 1 en la columna que corresponde a la diagonal (misma posición) y 0 en las demás.
4. Se entrega la matriz completa.

Validaciones y mensajes de error

- Si el tamaño no se proporciona o es menor o igual a cero: mensaje "El tamaño de la matriz debe ser mayor o igual a 1" o "hay datos faltantes".
- Si el valor proporcionado no es numérico: mensaje "Introducir sólo números".

---

## Ejercicio 5 — Suma y promedio por filas y columnas

Descripción del problema

Calcular la suma y el promedio de cada fila y de cada columna de una matriz de números.

Análisis (Entradas / Proceso / Salida)

- Entradas: Una matriz con al menos una fila y una columna, con números.
- Proceso: Calcular la suma total de cada fila y cada columna, y dividir por el número de elementos correspondientes para obtener los promedios.
- Salida: Cuatro listas: suma por fila, promedio por fila, suma por columna y promedio por columna.

Funcionamiento paso a paso (explicación amigable)

1. Se recibe la tabla de números y se comprueba que tenga filas y columnas.
2. Para cada fila se suman sus números y se calcula el promedio (suma dividido por cantidad de columnas).
3. Para cada columna se suman los números de esa columna en todas las filas y se calcula su promedio (suma dividido por cantidad de filas).
4. Se devuelven las cuatro listas con los resultados.

Validaciones y mensajes de error

- Si la matriz falta, está vacía o no tiene columnas: mensaje "hay datos faltantes".
- Si alguna fila es nula o tiene diferente cantidad de columnas: mensaje "Estructura de matriz inválida" o "hay datos faltantes".
- Si hay valores no numéricos: mensaje "Introducir sólo números".

---

## Ejercicio 6 — Análisis de ventas

Descripción del problema

Dada una matriz donde cada fila representa un mes y cada columna un día, encontrar la venta mínima, la venta máxima, el total de ventas y las ventas acumuladas por día.

Análisis (Entradas / Proceso / Salida)

- Entradas: Una matriz de enteros que representa ventas (meses x días).
- Proceso: Recorrer todas las ventas para identificar la mínima y máxima (con su posición), sumar el total y acumular ventas por cada día.
- Salida: Objeto que contiene: venta mínima (valor y posición), venta máxima (valor y posición), venta total y un arreglo con la suma por día.

Funcionamiento paso a paso (explicación amigable)

1. Se recibe la tabla de ventas y se valida que tenga datos.
2. Se revisan todas las celdas para encontrar la venta más baja y la más alta, y se recuerda en qué mes y día ocurrieron.
3. Se suma cada valor para obtener el total de ventas.
4. Para cada día (columna) se acumulan las ventas a lo largo de los meses.
5. Se devuelve un resumen con toda la información.

Validaciones y mensajes de error

- Si la matriz falta, está vacía o no tiene columnas: mensaje "hay datos faltantes".
- Si las filas no tienen la misma cantidad de días: mensaje "Estructura de matriz inválida".
- Si hay valores no numéricos: mensaje "Introducir sólo números".

---

## Ejercicio 7 — Análisis de calificaciones

Descripción del problema

Analizar las calificaciones de varios alumnos (cada alumno tiene varias notas) para obtener el promedio por alumno, el promedio más alto y más bajo, número de parciales reprobados y distribuir los promedios en rangos.

Análisis (Entradas / Proceso / Salida)

- Entradas: Una matriz de números (cada fila: las calificaciones de un alumno).
- Proceso: Calcular el promedio por alumno, luego obtener el promedio más alto y más bajo entre alumnos, contar notas por debajo de la nota mínima aprobatoria y clasificar promedios por rangos.
- Salida: Un objeto con promedios por alumno, promedio más alto, promedio más bajo, cantidad de parciales reprobados y una distribución por rangos.

Funcionamiento paso a paso (explicación amigable)

1. Se verifica que existan calificaciones y que la estructura sea regular.
2. Para cada alumno se calcula su promedio sumando sus notas y dividiendo por la cantidad de notas.
3. Entre todos los alumnos se busca el promedio más alto y el más bajo.
4. Se cuenta cuántas notas (parciales) están por debajo de la nota mínima aprobatoria (por ejemplo 7.0).
5. Se agrupan los promedios en rangos predefinidos (ej.: 0-4.9, 5.0-5.9, etc.) para obtener una distribución.

Validaciones y mensajes de error

- Si la matriz falta o está vacía: mensaje "hay datos faltantes".
- Si alguna fila no contiene calificaciones válidas o hay datos no numéricos: mensaje "Introducir sólo números".
- Si la estructura es inconsistente entre alumnos: mensaje "Estructura de matriz inválida".

---

## Ejercicio 8 — Revertir un arreglo (recursión)

Descripción del problema

Invertir el orden de los elementos de una lista de números (por ejemplo, transformar [1,2,3] en [3,2,1]).

Análisis (Entradas / Proceso / Salida)

- Entradas: Un arreglo (lista) de números enteros.
- Proceso: Intercambiar elementos desde los extremos hacia el centro hasta invertir toda la lista.
- Salida: El arreglo invertido.

Funcionamiento paso a paso (explicación amigable)

1. Se recibe la lista de números.
2. Se toma el primer y el último elemento y se intercambian.
3. Se repite el intercambio con los siguientes elementos hacia el centro hasta terminar.
4. Se devuelve la lista ya invertida.

Validaciones y mensajes de error

- Si falta el arreglo: mensaje "hay datos faltantes".
- Si contiene valores no numéricos: mensaje "Introducir sólo números".

---

## Ejercicio 9 — Contar ocurrencias (recursión)

Descripción del problema

Contar cuántas veces aparece un valor específico dentro de una lista de números.

Análisis (Entradas / Proceso / Salida)

- Entradas: Un arreglo de números y un valor objetivo a contar.
- Proceso: Revisar cada elemento y sumar 1 cuando coincide con el valor objetivo.
- Salida: Un número que indica cuántas veces apareció el valor en el arreglo.

Funcionamiento paso a paso (explicación amigable)

1. Se recibe la lista y el valor a buscar.
2. Se recorre la lista elemento por elemento.
3. Cada vez que un elemento coincide con el valor buscado, se incrementa un conteo.
4. Al finalizar, se devuelve el conteo total.

Validaciones y mensajes de error

- Si falta el arreglo o el valor a buscar: mensaje "hay datos faltantes".
- Si hay valores no numéricos: mensaje "Introducir sólo números".

---

## Ejercicio 10 — Aplanar matriz y calcular estadísticas

Descripción del problema

Transformar una matriz de varias filas (posiblemente con diferentes longitudes) en una sola lista de números y calcular estadísticas básicas: suma, mínimo, máximo y promedio.

Análisis (Entradas / Proceso / Salida)

- Entradas: Una matriz (lista de filas) de números; las filas pueden tener longitudes distintas (matriz jagged).
- Proceso: Reunir todos los números en una sola lista y calcular la suma total, el menor, el mayor y el promedio.
- Salida: Un resumen con la lista aplanada, la suma, el mínimo, el máximo y el promedio.

Funcionamiento paso a paso (explicación amigable)

1. Se recibe la tabla de números que puede tener filas de distintos tamaños.
2. Se recorren todas las filas y se añaden sus números a una sola lista ordenada por filas y columnas.
3. Con esa lista completa se calcula la suma, se identifica el menor y el mayor y se calcula el promedio.
4. Se devuelve la lista aplanada y las estadísticas solicitadas.

Validaciones y mensajes de error

- Si la matriz falta o está vacía: mensaje "hay datos faltantes".
- Si hay valores no numéricos: mensaje "Introducir sólo números".

---

## Buenas prácticas para las pruebas (qué verificar)

- Verificar que ante entradas faltantes la API responda con un mensaje claro: "hay datos faltantes" y un código que indique mala petición.
- Verificar que valores no numéricos sean reportados con el mensaje "Introducir sólo números".
- Comprobar, cuando aplique, mensajes específicos de estructura: "Dimensiones incompatibles", "La matriz debe ser cuadrada", o "Estructura de matriz inválida".
- Revisar resultados límite: divisiones por cero deben reflejarse como "infinito" o manejarse sin detener el procesamiento completo.
- Para cada operación, comparar la lógica esperada (por ejemplo: conteo de ceros, suma por fila) con el resultado devuelto por la API.

## Notas finales

- Esta API ya incluye manejo global de errores que traduce errores internos en mensajes JSON fáciles de entender.
- Si deseas, puedo preparar una versión del documento con ejemplos paso a paso y peticiones concretas para cada endpoint, o una guía para testers con entradas de prueba y respuestas esperadas.

---

Archivo fuente: `src/Controllers/ArrayController.cs`, `src/Services/ArrayService.cs`, `src/Models/Dtos/ArrayDtos.cs`, `src/Middleware/GlobalExceptionHandler.cs`, `src/Attributes/MustBePositiveAttribute.cs`, `src/Services/ArrayAnalyzer.cs`.

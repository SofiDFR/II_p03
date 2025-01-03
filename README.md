# Interfaces Inteligentes: Movimientos
## Ejercicio 1
```cs
public float speed = 5f;
```
La `velocidad` es un atributo público de la clase para que se pueda modificar desde el inspector

```cs
void Update()
{
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
    transform.Translate(movement);

    if (Input.GetKey(KeyCode.UpArrow))
    {
        Debug.Log(keyCode + (speed * vertical));
    }
    else if (Input.GetKey(KeyCode.DownArrow))
    {
        Debug.Log(keyCode + (speed * vertical));
    }
    else if (Input.GetKey(KeyCode.LeftArrow))
    {
        Debug.Log(keyCode + (speed * horizontal));
    }
    else if (Input.GetKey(KeyCode.RightArrow))
    {
        Debug.Log(keyCode + (speed * horizontal));
    }
}
```
1. 

![ej_1](docs/p03_001.gif)
## Ejercicio 2
Antes de nada, se debe asignar la `tecla H` al comando `Shoot` (Disparo). Para ello vamos a `Edit > proyect Settings > Input Manager > Axes` y allí creamos uno nuevo y ponemos la siguiente información:

![tecla_shoot](docs/shoot.PNG)

```cs
public GameObject bulletPrefab;
public float bulletSpeed = 10f;
public Transform shootingPoint;
```
1. En el propio editor se creó un `prefab` de una bala (una esfera). Este script recibe este objeto como parámetro. Se puede arrastrar desde el inspector
2. `bulletSpeed` es la velocidad a la que saldrá disparada la bala. Se puede modificar desde el inspector
3. Y el `shootingPoint` es un objeto vacío colocado enfrente del cubo que actuará como `punto de salida para la bala`. Se asigna desde el inspector

```cs
void Update()
{
    if (Input.GetButtonDown("Shoot"))
    {
        Debug.Log("Disparo realizado");
        ExecuteShot();
    }
}
```
Si la tecla pulsada se corresponde al del comando `Shoot (H)`, muestra por consola que se ha realizado el disparo y llama a la función que lo ejecuta

```cs
void ExecuteShot()
{
    GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);

    Rigidbody rb = bullet.GetComponent<Rigidbody>();
    if (rb != null)
    {
        rb.velocity = shootingPoint.forward * bulletSpeed;
    }
    Debug.Log("Shot!");
}
```

![ej_1](docs/p03_002.gif)
## Ejercicio 3
```cs
    public Vector3 moveDirection = new Vector3(1, 0, 0);
    public float speed = 2f;
```
- `moveDirection` es el vector que indica la dirección del movimiento. Se puede modificar desde el inspector. Inicialmete a (1, 0, 0)
- `speed` determina la velocidad a la que se mueve el cubo. Inicialmente igual a 2

```cs
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
```
Simplemente se establece la posición inicial del cubo con el `eje y = 0`

```cs
    void Update()
    {
        transform.Translate(moveDirection.x * speed * Time.deltaTime, moveDirection.y * speed * Time.deltaTime, moveDirection.z * speed * Time.deltaTime);
    }
```
Mueve el cubo en cada frame en la dirección especificada (`moveDirection`) multiplicada por 'speed'. Se usa `Time.deltaTime` para asegurar que el movimiento sea suave e independiente de la velocidad de los fotogramas

![ej_3](docs/p03_3_001.gif)

### Resultado 1
- **moveDirection** = (2, 0, 0)
- **speed** = 2
- **Posición cubo** = (0, 0, 0)

El cubo se moverá el doble de rápido en la misma dirección especificada originalmente. Avanzará el doble de la distancia por cada frame porque las coordenadas de la dirección son ahora mayores

![ej_3](docs/p03_3_002.gif)

### Resultado 2
- **moveDirection** = (1, 0, 0)
- **speed** = 4
- **Posición cubo** = (0, 0, 0)

El cubo se moverá más rápido, cubriendo más distancia por frame. La dirección no cambia

![ej_3](docs/p03_3_003.gif)

### Resultado 3
- **moveDirection** = (1, 0, 0)
- **speed** = 0.5
- **Posición cubo** = (0, 0, 0)

El cubo se moverá más lento, avanzando menos distancia por frame

![ej_3](docs/p03_3_004.gif)

### Resultado 4
- **moveDirection** = (1, 0, 0)
- **speed** = 2
- **Posición cubo** = (0, 1, 0)

El cubo se moverá en la dirección establecida, simpemente a una mayor altura

![ej_3](docs/p03_3_005.gif)

### Resultado 5
```cs
```
- **Sistema de referencia local:** Por defecto, `transform.Translate()` usa el sistema de referencia local del objeto, por lo que el cubo se seguirá moviendo en la misma dirección que en las pruebas anteriores

![ej_3](docs/p03_3_001.gif)

```cs
transform.Translate(moveDirection.x * speed * Time.deltaTime, moveDirection.y * speed * Time.deltaTime, moveDirection.z * speed * Time.deltaTime. Space.World);
```
- Ahora el cubo se moverá usando el sistema de coordenadas del propio mundo y no el suyo propio (local). Para esta prueba se rotó el cubo para que sus ejes no fueran iguales y se pudiera ver la diferencia. En este caso, el cubo va hacia el lado contrario.

![ej_3](docs/p03_3_006.gif)

## Ejercicio 4
```cs
    public float speed = 5f;
    public GameObject cube;
    public GameObject sphere;
```
- `speed` es la velocidad el objeto
- `cube` y `sphere` son referencias a los objetos correspondientes

```cs
    void Update()
    {
        InputMoveCube();
        InputMoveSphere();
    }
```
Simplemente llama a las funciones que mueve a cada objeto con sus respectivas teclas

```cs
    void InputMoveCube()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            cube.transform.Translate(Vector3.forward * speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            cube.transform.Translate(Vector3.back * speed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            cube.transform.Translate(Vector3.left * speed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            cube.transform.Translate(Vector3.right * speed);
        }
        
    }
```
Si el input es la `tecla flecha`, el cubo se moverá en su correspondiente dirección gracias a la función `Translate`

```cs
    void InputMoveSphere()
    {
        if (Input.GetKey(KeyCode.W))
        {
            sphere.transform.Translate(Vector3.forward * speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            sphere.transform.Translate(Vector3.back * speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            sphere.transform.Translate(Vector3.left * speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            sphere.transform.Translate(Vector3.right * speed);
        }
    }
```
Si el input es `w`, `a`, `s`, `d`, el cubo se moverá en su correspondiente dirección (arriba, izquierda, abajo, derecha respectivamente) gracias a la función `Translate`

***Nota:*** Como no se usa `Time.deltaTime`, los movimientos se ven bruscos y salteados

![ej_3](docs/p03_005.gif)
## Ejercicio 5
Primero hay que asignar:
- **Horizontal:** `Flechas izquierda y derecha` (eliminamos de teclas alternativas la `A` y `D`)
- **Vertical:** `Flechas arriba y abajo` (eliminamos de teclas alternativas la `W` y `S`)
- **HorizontalSphere:** `A` y `D`
- **VerticalSphere:** `W` y `S`
  
```cs
    public float speed = 5f;
    public GameObject cube;
    public GameObject sphere;
```
- `speed` es la velocidad el objeto
- `cube` y `sphere` son referencias a los objetos correspondientes

```cs
    void Update()
    {
        MoveCube();
        MoveSphere();
    }
```
Simplemente llama a las funciones que mueve a cada objeto con sus respectivas teclas

```cs
    void MoveCube()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        cube.transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    void MoveSphere()
    {
        float horizontal = Input.GetAxis("HorizontalSphere");
        float vertical = Input.GetAxis("VerticalSphere");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        sphere.transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
```

1. Se obtienen los valores de movimiento del usuario con `Input.GetAxis()`
2. Se crea un vector de dirección con `y = 0`
3. Con `Translate()` se mueve el objeto correspondiente. `Time.deltaTime` permite que el movimiento sea uniforme sin importar los frames por segundo
   
![ej_3](docs/p03_004.gif)

## Ejercicio 6
***Nota:*** Los atributos de la clase son los mismos que los del **ejercicio 5**

```cs
    void Update()
    {
        MoveCubeTowardsSphere();
        MoveSphere();
    }
```
Simplemente llama a las funciones que mueve a cada objeto con sus respectivas teclas

```cs
    void MoveCubeTowardsSphere()
    {
        Vector3 direction = sphere.transform.position - cube.transform.position;
        direction.y = 0;

        Vector3 moveDirection = direction.normalized;

        cube.transform.Translate(moveDirection * (speed - 2) * Time.deltaTime, Space.World);
    }
```
1. Se calcula la dirección hacia la que el cubo debe moverse. Al restar la posición del `cubo` de la posición de la `esfera`, obtienes un vector que apunta desde el cubo hacia la esfera
2. se establece `y = 0` para evitar cualquier movimiento vertical
3. Se normaliza el vector de dirección para que tenga `magnitud 1`, permitiendo mover el cubo en esa dirección sin importar la distancia real
4. Con `Translate()` se mueve el cubo a una velocidad de `speed - 2` para que este siempre vaya más lento que la esfera

![ej_6](docs/p03_006.gif)

## Ejercicio 7
***Nota:*** Los atributos de la clase son los mismos que los del **ejercicio 5**

```cs
    void Update()
    {
        MoveAndRotateTowardSphere();
        MoveSphere();
    }
```
Simplemente llama a las funciones que mueve a cada objeto con sus respectivas teclas

```cs
    void MoveAndRotateTowardSphere()
    {
        cube.transform.LookAt(sphere.transform);
        cube.transform.Translate(Vector3.forward * (speed - 2) * Time.deltaTime);
    }
```
1. Primero se hace que el cubo gire para mirar hacia la dirección de la `esfera`, alineando su frente (el eje Z local del cubo) hacia la posición de la esfera
2. Se mueve el cubo en su propio sistema de coordenadas locales (hacia su frente) usando `Vector3.forward`
   
![ej_7](docs/p03_007.gif)

## Ejercicio 8
```cs
    public float speed = 5f;
    public float rotationSpeed = 100f;
```
- La velocidad de movimiento
- La velocidad de rotación

```cs
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);

        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        Debug.DrawRay(transform.position, transform.forward * 5, Color.red);
    }
```
1. Se obtiene el valor de entrada del usuario para el `eje horizontal`
2. El objeto gira entorno a su `eje y`, por lo que solo puede girar hacia los lados
3. Se mueve el objeto con `Translate()` sobre el eje de coordenadas del mundo
4. Con `Debug.DrawRay()` se dibuja una línea en la escena (que solo se puede ver desde el editor) desde la posición del objeto hacia delante. Ayuda a visualizar la dirección en la mira y se mueve el objeto

![drawray](docs/red_line.PNG)

![ej_8](docs/p03_008.gif)
## Ejercicio 9
El script se le asigna al `cilindro`
```cs
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "plane")
        {
            Debug.Log("Colisión con: " + collision.gameObject.tag);
        }
    }
```
1. `OnCollisionEnter()` se activa cuando el objeto al que está unido al script (el cilindro) colisiona con otro objeto
2. Se el objeto no es el plano (siempre está en contacto con el plano) se imprime por consola el objeto con el que se ha colisionado

![ej 9](docs/p03_009.gif)
![collisions](docs/collisions.PNG)
## Ejercicio 10
```cs
    public float speed = 5f;
    public float rotationSpeed = 10f;
```
- La velocidad de movimiento
- La velocidad de rotación

```cs
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        if (moveDirection.magnitude > 0)
        {
            Quaternion rotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
       
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        }
    }
```
1. Se obtienen los movimientos del usuario con `Input.GetAxis()`
2. Se crea un vector de dirección
3. Se comprueba si hay movimiento
4. Con `Quaternion.LookRotation(moveDirection)` se consigue que el objeto mire en la dirección hacla la que se mueve
5. Con `Quaternion.Slerp()` se suaviza la rotación, ajustando la rotación actual (`transform.rotation`) hacia la nueva rotación calculada a una velocidad determinada por `rotationSpeed`
6. Se mueve el objeto con `Translate()`

***Nota:*** Se hicieron dos versiones del ejercicio
1. El cubo es `cinemático` pero no tiene script asociado. Se observa que no reacciona ante las físicas
![ej 10](docs/p03_10_001.gif)

2. El cubo es `cinemático` y tiene script asociado. Ahora gracias al script, el cubo se mueve
![ej 10](docs/p03_10_002.gif)

## Ejercicio 11
```cs
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("El objeto que ha entrado en el Trigger es: " + other.gameObject.tag);
    }
```
1. `OnTriggerEnter()` se ejecuta cuando un objeto con un collider que tiene la opción `Is Trigger` activada es atravesado por otro objeto con un `collider` y un `Rigidbody`
2. Cada vez que se activa, se imprime por consola el objeto que lo ha atravesado

![trigger](docs/trigger.PNG)
![ej 11](docs/p03_011.gif)

## Ejercicio 12

- Al cilindro se le asignaron las siguientes teclas:
    - Arriba: `I`
    - Abajo: `K`
    - Derecha: `L`
    - Izquierda: `J` 

```cs
    public Transform sphere;
    public float moveSpeed = 5f;
    public float turnSpeed = 3f;
    private Rigidbody rb;
```
- Referencia a la esfera a la que tiene que girarse el cilindro cuando no esté en movimiento
- Velocidad de movimiento
- Velocidad de giro
- El Rigidbody del objeto (el cilindro)

```cs
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
```
1. Se recupera el componente `Rigidbody` del objeto al que está asociado el script. Necesario para aplicarle las fuerzas
2. Se añaden restricciones en los ejes `X` y `Z` para que el cilindro no se caiga

```cs
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("HorizontalCylinder");
        float vertical = Input.GetAxis("VerticalCylinder");

        if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
        {
           
            Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;

            Quaternion toRotation = Quaternion.LookRotation(moveDirection);
            rb.rotation = Quaternion.Slerp(rb.rotation, toRotation, turnSpeed * Time.deltaTime);

            rb.AddForce(moveDirection * moveSpeed * 2f);
        }
        else
        {
            if (sphere != null)
            {
                Vector3 lookAtGoal = new Vector3(sphere.position.x, this.transform.position.y, sphere.position.z);

                Vector3 directionToSphere = (lookAtGoal - transform.position).normalized;

                Quaternion rotationToSphere = Quaternion.LookRotation(directionToSphere);
                rb.MoveRotation(Quaternion.Slerp(rb.rotation, rotationToSphere, turnSpeed * Time.fixedDeltaTime));
            }
        }
    }
```
1. Se utiliza `FixedUpdate` para manejar lo que está relacionado con la física, es decir, porque se está interactuando directamente con el `Rigidbody` del cilindro y se está aplicando fuerzas físicas como `AddForce()`
2. Se obtienen los movimientos del usuario con `Input.GetAxis()` Se capturan las
3. `if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)` verifica si el jugador está presionando alguna tecla delmovimiento. (El umbral 0.1f evita movimientos accidentales)
    1. Se crea un vector de dirección
    2. Se rota el cilindro hacia la dirección del movimiento
    3. Se aplica fuerza con `AddForce` en dirección del movimiento del cilindro. La fuerza es proporcional a la velocidad
4. Cuando no hay movimiento
    1. Se verifica que hay una esfera asignada para evitar errores
    2. Se calcula la dirección hacia la esfera
    3. Se rota el cilindro hacia la esfera 

**Resultados:**
- Masa esfera (10) > Masa cilindro (1)
Al cilindro le cuesta mover la esfera ya que es mucho más pesada
![12 1](docs/p03_12_001.gif)

- Masa esfera (0.5) < Masa cilindro (1)
El cilindro mueve la esfera con facilidad ya que es mucho más ligera
![12 2](docs/p03_12_003.gif)

- Esfera como objeto cinemático
La esfera no reacciona fisicamente a las colisiones. El cilindro no puede mover la esfera
![12 3](docs/p03_12_002.gif)

- Esfera como trigger
El cilindro atraviesa la esfera sin colisionar físicamente con ella, pero se pueden utilizar eventos de detección para detectar cuándo el cilindro pasa a través de la esfera
![12 4](docs/p03_12_004.gif)

- Aumentar fricción de cilindro. De 0.6 a 1.5
El cilindro se mueve de forma más lenta y se detiene más rápido
![12 5](docs/p03_12_005.gif)

- Disminuir la fricción. De 0.6 a 0.3
EL cilindro se mueve más rápido y al dejar de pulsar la tecla movimiento, se sigue deslizando por el plano (por falta de fricción)
![12 6](docs/p03_12_006.gif)

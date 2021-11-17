using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceWalker : MonoBehaviour
{
    //posicion y velocidad
    [SerializeField] private Vector2 thisPosition, velocidad;

    //limite
    [SerializeField] float rapidezlimite = 5f;

    //fuerzas
    [SerializeField] Vector2 fuerza1 = new Vector2(0, 0);
    [SerializeField] Vector2 fuerza2 = new Vector2(0, 0);
    [SerializeField] Vector2 gravedad = new Vector2(0, -9.8f);

    [SerializeField] [Range(0, 1)] float coeficienteFriccionTierra = 1f;

    //masa del cuerpo 
    [SerializeField] float N = 20f;
    [SerializeField] float masa = 1f;
    [SerializeField] bool pesoBool = true;
    private Vector2 peso;

    //total de las fuerzas
    [SerializeField] Vector2 fuerzaAcumulada = new Vector2(0, 0);

    //fluidos
    [SerializeField] float rho = 0f;
    [SerializeField] bool fluidoEnter = false;
    [SerializeField] float areaContacto = 0f;
    [SerializeField] [Range(0, 1)] float coeficienteFriccionFluido = 1f;

    //Friccion
    [SerializeField] bool BoolFriccion = true;

    //Gravedad
    [SerializeField] ForceWalker objetoGravitacional;
    [SerializeField] float Gmagico = 1f;
    [SerializeField] bool GravitacionActivada = true;

    private void Start()
    {
        thisPosition = this.transform.position;
    }

    void Update()
    {
        UpdatePosition();
        transform.position = thisPosition;
    }

    public void UpdatePosition()
    {

        //fuerzas
        fuerzaAcumulada.x = 0;
        fuerzaAcumulada.y = 0;

        //Calcular Friccion
        if (BoolFriccion)
        {
            SumarFuerzas(AplicarFriccion());
        }

        //fuerza de fluidos
        FluidoEntrada();

        //Aplicacion de fuerzas
        ApplyForce(fuerza1);
        ApplyForce(fuerza2);

        if (pesoBool)
        {
            ApplyGravity();
        }

        if (GravitacionActivada)
        {
            FuerzaGravitacional(objetoGravitacional);
        }

        //sumar la aceleracion a la velocidad
        fuerzaAcumulada = fuerzaAcumulada * (1 / masa);

        //Aplciar aceleracion a la velocidad
        velocidad = velocidad + (fuerzaAcumulada * (Time.deltaTime));


        //rapidez limite para que no sobrepase el ecceso
        if (velocidad.magnitude > rapidezlimite)
        {
            velocidad = velocidad.normalized;
            velocidad = velocidad * (rapidezlimite);
        }

        //se le suma la veclocidad a la posicion
        thisPosition = thisPosition + (velocidad * (Time.deltaTime));
    }

    private void FuerzaGravitacional(ForceWalker gravitacion)
    {
        gravitacion = gravitacion.GetComponent<ForceWalker>();

        float m2 = gravitacion.masa;
        Vector2 V1 = thisPosition;
        Vector2 V2 = gravitacion.thisPosition;
        Vector2 diferencia = V2 - (V1);
        float distanciaSeparacion = diferencia.magnitude;
        Vector2 direccion = diferencia.normalized;
        Vector2 fuerzaGravitacional = direccion * ((Gmagico * masa * m2) / Mathf.Pow(distanciaSeparacion, 2));
        SumarFuerzas(fuerzaGravitacional);
    }

    private void FluidoEntrada()
    {
        if (fluidoEnter)
        {
            Vector2 fuerzaFluido = new Vector2(0f, 0f);
            Vector2 velocidadNormalizada = velocidad.normalized;
            float cuadradoV = Mathf.Pow(velocidad.magnitude, 2);
            fuerzaFluido = velocidadNormalizada * ((-1f / 2f) * rho * cuadradoV * coeficienteFriccionFluido * areaContacto);
            SumarFuerzas(fuerzaFluido);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            fluidoEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            fluidoEnter = false;
        }
    }

    private Vector2 AplicarFriccion()
    {
        Vector2 friccion = velocidad.normalized;
        friccion = friccion * (-coeficienteFriccionTierra * N);
        return friccion;
    }

    private void ApplyForce(Vector2 fuerzaAplicar)
    {
        Vector2 solucion = fuerzaAplicar * (1 / masa);
        SumarFuerzas(solucion);
    }

    private void ApplyGravity()
    {
        peso = gravedad * (masa);
        SumarFuerzas(peso);
    }

    private void SumarFuerzas(Vector2 fuerzaExtra)
    {
        fuerzaAcumulada = fuerzaAcumulada + (fuerzaExtra);
    }

}

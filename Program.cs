

//clase abstracta fomr
public abstract class Shape
{
    protected IDrawingAPI drawingAPI;

    protected Shape(IDrawingAPI drawingAPI)
    {
        this.drawingAPI = drawingAPI;
    }

    public abstract void Draw();
}

//interface para dibujar
public interface IDrawingAPI
{
    //metodo(implementar logica)
    void DrawShape();
}

//clase circulo hereda de Shape
public class Circle : Shape 
{
    private int raduis;
    public Circle(int radius, IDrawingAPI drawingAPI) : base(drawingAPI) 
    {
        this.raduis = radius;
    }
    //metodo draw
    public override void Draw()
    {
        drawingAPI.DrawShape();
    }

}
//clase Rectangle hereda de Shape
public class Rectangle : Shape
{
    private int width;
    private int height;

    public Rectangle(int width, int height, IDrawingAPI drawingAPI) : base(drawingAPI)
    {
        this.width = width;
        this.height = height;
    }
    //metodo draw
    public override void Draw()
    {
        drawingAPI.DrawShape();
    }

    //clase para dibujar
    public class WindowDrawingAPI : IDrawingAPI
    {
        public void DrawShape()
        {
            Console.WriteLine("Drawing shape on the window");
        }
             
    }

    //clase para imprimir
    public class PrinterDrawingAPI : IDrawingAPI
    {
        public void DrawShape()
        {
            Console.WriteLine("Printing shape on the printer");
        }
    }

    //clase para enviar por correo
    public class EmailDrawingAPI : IDrawingAPI
    {
        public void DrawShape()
        {
            Console.WriteLine("Sending shape via e mail");
        }
    }


    //Ejecucion del programa
    class Program
    {
        static void Main(string[] args)
        {
            //crear instancia Circle con la implementacion de dibujo en la ventana    
            Shape circle = new Circle(5, new WindowDrawingAPI());
            circle.Draw();
            //crear instancia de Rectangle con la implementacion de dibujo en la impresora    
            Shape rectangle = new Rectangle(10, 8, new PrinterDrawingAPI());
            rectangle.Draw();
            //crear instancia de Circle con la implementacion de dibujo via email
            Shape circleEmail = new Circle(10, new EmailDrawingAPI());
            circleEmail.Draw();

            Console.ReadKey();  
        }
    }
}

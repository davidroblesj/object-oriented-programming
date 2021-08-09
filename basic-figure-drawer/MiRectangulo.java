package miFigura;
import java.awt.Color;
import java.awt.Graphics; 
import javax.swing.JPanel;

public class MiRectangulo extends MiFiguraDelimitada {
	public MiRectangulo() {
		super();
		
	}
	public MiRectangulo(Punto p1,Punto p2,Color c,boolean relleno) {
		super(p1,p2,c,relleno);
		
	}
	@Override
	public void dibujar(Graphics g) {
		g.setColor(this.getColor());
		if(getRelleno()==true)
			g.fillRect(p1().x, p1().y, anchura(), altura());
		else
			g.drawRect(p1().x, p1().y, anchura(), altura());
		
		
	
	}
}

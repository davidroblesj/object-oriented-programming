package miFigura;
import java.awt.Color;
import java.awt.Graphics; 
import javax.swing.JPanel;
import java.lang.Math;

public class MiOvalo extends MiFiguraDelimitada {
	public MiOvalo() {
		super();
		
	}
	public MiOvalo(Punto p1,Punto p2,Color c,boolean relleno) {
		super(p1,p2,c,relleno);
		
	}
	
	@Override
	public void dibujar(Graphics g) {
		g.setColor(this.getColor());
		if(getRelleno()==true)
			g.fillOval(p1().x, p1().y, anchura(), altura());
		else
			g.drawOval(p1().x, p1().y, anchura(), altura());
		
			
		
	}
}

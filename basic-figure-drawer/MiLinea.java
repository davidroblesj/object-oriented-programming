package miFigura;
import java.awt.Color;
import java.awt.Graphics; 
import javax.swing.JPanel;

public class MiLinea extends MiFigura{
	public MiLinea() {
		super();
		
	}
	public MiLinea(Punto p1,Punto p2,Color c) {
		super(p1,p2,c,false);
		
	}
	
	@Override
	public void dibujar(Graphics g) {
		g.setColor(getColor());
		 g.drawLine(this.getp1().x,this.getp1().y,this.getp2().x,this.getp2().y);
		
	}
	
	

	

}

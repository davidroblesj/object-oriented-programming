package miFigura;
import java.awt.Color;
import java.awt.Graphics; 
import javax.swing.JPanel;
public abstract class MiFigura{
	private Punto p1,p2;
	private Color color;
	private boolean relleno;
	
	public MiFigura() {
		this.p1=new Punto(0,0);
		this.p2=new Punto(0,0);
		this.color=new Color(255,255,255);
		this.relleno=false;
	}
	
	public MiFigura(Punto p1,Punto p2,Color c,boolean relleno) {
		setp1(p1);
		setp2(p2);
		setColor(c);
		setRelleno(relleno);
	}
	
	public void setp1(Punto p1) {
		this.p1=new Punto(p1.x,p1.y);

	}
	public void setp2(Punto p2) {
		this.p2=new Punto(p2.x,p2.y);

	}
	public void setColor(Color c) {
		this.color=c;
	}
	public Punto getp1() {
		return this.p1;

	}
	public Punto getp2() {
		return this.p2;

	}
	public Color getColor() {
		return this.color;

	}
	public void setRelleno(boolean relleno) {
		this.relleno=relleno;
	}
	public boolean getRelleno() {
		return this.relleno;

	}
	public abstract void dibujar(Graphics g);

}

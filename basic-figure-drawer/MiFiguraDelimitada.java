package miFigura;

import java.awt.Color;
import java.awt.Graphics;

public abstract class MiFiguraDelimitada extends MiFigura{
	public MiFiguraDelimitada() {
		super();
		
	}
	public MiFiguraDelimitada(Punto p1,Punto p2,Color c,boolean relleno) {
		super(p1,p2,c,relleno);
		
	}
	
	public Punto p1() {
		if(this.getp1().x>this.getp2().x && this.getp1().y>this.getp2().y) {
			Punto p1=new Punto(this.getp1().x,this.getp1().y);
			return p1;
		}
		else if(this.getp1().x<this.getp2().x && this.getp1().y>this.getp2().y) {
			Punto p1=new Punto(this.getp2().x,this.getp1().y);
			return p1;
		}
		else if(this.getp1().x>this.getp2().x && this.getp1().y<this.getp2().y) {
			Punto p1=new Punto(this.getp1().x,this.getp2().y);
			return p1;
		}
		else {
			Punto p1=new Punto(this.getp2().x,this.getp2().y);
			return p1;
		}
	}
	public int anchura() {
		return Math.abs(this.getp1().x-this.getp2().x);
	}
	public int altura() {
		return Math.abs(this.getp1().y-this.getp2().y);
	}
	
}

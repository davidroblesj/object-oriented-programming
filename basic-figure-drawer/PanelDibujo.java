package miFigura;
import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseMotionListener;

import javax.swing.JLabel;
import javax.swing.JPanel;


public class PanelDibujo extends JPanel{
	private MiFigura[] figura;
	private int cuentaFiguras;
	private int tipoFigura;
	private MiFigura figuraActual;
	private Color colorActual;
	private boolean figuraRellena;
	JLabel etiquetaEstado;
	public PanelDibujo (JLabel etiqueta) {
		etiquetaEstado=etiqueta;
		this.figura=figura;
		figura=new MiFigura[100];
		cuentaFiguras=0;
		tipoFigura=0;
		figuraActual=null;
		colorActual=new Color(0,0,0);
		figuraRellena=false;
	
		super.setBackground( Color.WHITE );
		ManejarRaton manejador=new ManejarRaton();
	    super.addMouseListener(manejador); 
	    super.addMouseMotionListener( manejador ); 
		
	}
	
   public void paintComponent( Graphics g ){
	   super.paintComponent(g);
	   int i;
		   if (figuraActual!=null) {
			   figuraActual.dibujar(g);
		   }
	   for(i=0;i<cuentaFiguras;i++) {
		   figura[i].dibujar(g);
	   }
	  
   }
   public void borrarUltimaFigura() {
	   if(cuentaFiguras>0) {
		   cuentaFiguras--;
	   		super.repaint();
	   }
	   else
		   cuentaFiguras=0;
   }
   public void borrarDibujo() {
	  
		   cuentaFiguras=0;
		   super.repaint();
   }
   public void setFiguraActual(int i) {
	   tipoFigura=i;
   }
   public void setColorActual(Color c) {
	   colorActual=c;
   }
   public void setFiguraRellena(boolean r) {
	   figuraRellena=r;
   }
   private class ManejarRaton extends MouseAdapter implements MouseMotionListener {
	public void mousePressed(MouseEvent evento) {
		Punto p1=new Punto(evento.getX(),evento.getY());
		Punto p2=new Punto(evento.getX(),evento.getY());

		if(tipoFigura==0) {
			figuraActual=new MiLinea(p1,p2,colorActual);
			
			
			
		}
		else if(tipoFigura==1){
			figuraActual=new MiOvalo(p1,p2,colorActual,figuraRellena);
		
		
		}
		else if(tipoFigura==2){
			figuraActual=new MiRectangulo(p1,p2,colorActual,figuraRellena);
		 
		}
	}
	public void mouseMoved( MouseEvent evento )
    {
       etiquetaEstado.setText( String.format( "Se movio en [%d, %d]", 
          evento.getX(), evento.getY() ) );
    }
	public void mouseReleased( MouseEvent evento )
    {
		Punto p2=new Punto(evento.getX(),evento.getY());
       figuraActual.setp2(p2);
       figura[cuentaFiguras]=figuraActual;
       figuraActual=null;
       cuentaFiguras++;
       repaint();

       
    }
	public void mouseDragged( MouseEvent evento )
    {
		 etiquetaEstado.setText( String.format( "Se arrastra en [%d, %d]", 
		          evento.getX(), evento.getY() ) );
		Punto p2=new Punto(evento.getX(),evento.getY());
	       figuraActual.setp2(p2);
	       repaint();
    }
   }
}

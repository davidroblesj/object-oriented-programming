package miFigura;


import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ItemEvent;
import java.awt.event.ItemListener;

import javax.swing.JButton;
import javax.swing.JCheckBox;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.Border;

//import fig14_15_16.MarcoBoton;

import javax.swing.JLabel;
import javax.swing.JOptionPane;


public class MarcoDibujo extends JFrame{
	private static final String colores[] = 
	      { "Negro", "Azul",  "Cyan", "Gris Oscuro", "Gris", "Verde",  "Gris claro"
	    		  , "Magenta", "Naranja", "Rosa",  "Rojo", "Blanco","Amarillo" };
	private static final String figurines[] = 
	      { "Linea", "Ovalo",  "Rectangulo"};
	
	private BorderLayout esquema;
	   public MarcoDibujo() {
		  super( "Dibujador" );
		 super.setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );
	      super.setSize( 1920, 1080 );
	      super.setVisible( true );
		  JLabel estado=new JLabel();
		  PanelDibujo paneldibujo=new PanelDibujo(estado);
		  //setLayout(new GridLayout(1,5));
	     add(estado,BorderLayout.SOUTH);
	     add(paneldibujo,BorderLayout.CENTER);
	     JPanel componentesup=new JPanel();
	     componentesup.setLayout(new GridLayout(1,5));
	     
	      JComboBox seleccionc=new JComboBox(colores);
	      seleccionc.setMaximumRowCount( 13 );
	      seleccionc.addItemListener(
	    	         new ItemListener() // clase interna anónima
	    	         {
	    	        	 int a;
	    	            public void itemStateChanged( ItemEvent evento )
	    	            {
	    	           
	    	               if ( evento.getStateChange() == ItemEvent.SELECTED )
	    	              
	    	                     a=seleccionc.getSelectedIndex();
	    	               		if(a==0)
	    	               			paneldibujo.setColorActual(Color.BLACK);
	    	               		else if (a==1)
	    	               			paneldibujo.setColorActual(Color.BLUE);
	    	               		else if (a==2)
	    	               			paneldibujo.setColorActual(Color.CYAN);
	    	               		else if (a==3)
	    	               			paneldibujo.setColorActual(Color.DARK_GRAY);
	    	               		else if (a==4)
	    	               			paneldibujo.setColorActual(Color.GRAY);
	    	               		else if (a==5)
	    	               			paneldibujo.setColorActual(Color.GREEN);
	    	               		else if (a==6)
	    	               			paneldibujo.setColorActual(Color.LIGHT_GRAY);
	    	               		else if (a==7)
	    	               			paneldibujo.setColorActual(Color.MAGENTA);
	    	               		else if (a==8)
	    	               			paneldibujo.setColorActual(Color.ORANGE);
	    	               		else if (a==9)
	    	               			paneldibujo.setColorActual(Color.PINK);
	    	               		else if (a==10)
	    	               			paneldibujo.setColorActual(Color.RED);
	    	               		else if (a==11)
	    	               			paneldibujo.setColorActual(Color.WHITE);
	    	               		else 
	    	               			paneldibujo.setColorActual(Color.YELLOW);
	    	               		
	    	            }
	    	         } 
	    	      );
	      componentesup.add(seleccionc);
	      JComboBox seleccionf=new JComboBox(figurines);
	      seleccionf.setMaximumRowCount( 3 );
	      seleccionf.addItemListener(
	    	         new ItemListener() // clase interna anónima
	    	         {
	    	        	 int a;
	    	            public void itemStateChanged( ItemEvent evento )
	    	            {
	    	           
	    	               if ( evento.getStateChange() == ItemEvent.SELECTED )
	    	              
	    	                     paneldibujo.setFiguraActual(seleccionf.getSelectedIndex());
	    	               		
	    	            }
	    	         } 
	    	      );
	    
	      componentesup.add(seleccionf);
	    JButton deshacer=new JButton("Deshacer");
	    deshacer.addActionListener(
	    new ActionListener(){
	    	 public void actionPerformed( ActionEvent evento )
	         {
	            paneldibujo.borrarUltimaFigura();
	         }
	    }
	    );
	    componentesup.add(deshacer);
	      JButton borrar=new JButton("Borrar");
	      borrar.addActionListener(
	    		    new ActionListener(){
	    		    	 public void actionPerformed( ActionEvent evento )
	    		         {
	    		            paneldibujo.borrarDibujo();
	    		         }
	    		    }
	    		    );
	      componentesup.add(borrar);
	   JCheckBox rellenador=new JCheckBox("Relleno");
	   rellenador.addItemListener(
			   new ItemListener() {

				@Override
				public void itemStateChanged(ItemEvent e) {
					// TODO Auto-generated method stub
				
						paneldibujo.setFiguraRellena(rellenador.isSelected());
				}
				   
			   });
	   componentesup.add(rellenador);
	   add(componentesup,BorderLayout.NORTH);
	  
	   }
	
}

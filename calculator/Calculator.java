package calculadora;

import java.awt.BorderLayout;
import java.awt.Container;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JComponent;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JTextField;

//import com.sun.tools.javac.code.Attribute.Array;

import javax.script.ScriptEngine;
import javax.script.ScriptEngineManager;
import javax.script.ScriptException;

import java.util.Arrays;
import java.util.List;
public class Calculator extends JFrame implements ActionListener 
{
	   private JButton[] botones; // arreglo de botones
	   private Container contenedor; // contenedor del marco
	   private GridLayout cuadricula1;
	   private GridLayout cuadricula2;// primer objeto GridLayout
	   private BoxLayout myBox;
	   private final String[] botonCalcu = 
		      { "C","-", "/","+", "*","0","1","2","3","4","5","6","7","8","9","="};
	   private final String[] botonCalcu2 = {"-", "/","+", "*","="};
	   private final String[] botonCalcu3 = {"0","1","2","3","4","5","6","7","8","9"};
	   private JTextField texto;
	   private String operacion;
	   private boolean operator=false;


	   public Calculator()
	   {
	      super( "Calculadora" );
	      cuadricula1 = new GridLayout( 4, 3); 
	     	      texto=new JTextField();
	     cuadricula2 = new GridLayout(2,1);
	     //myBox=new BoxLayout();
	      setLayout(cuadricula2); 
	      botones = new JButton[16];
	      add(texto);
	      JPanel mypane=new JPanel();
	      mypane.setLayout(cuadricula1);
	      //add(mypane, BorderLayout.SOUTH);
	      
	      for(int i=0;i<16;i++) {
	      botones[i]=new JButton(botonCalcu[i]); 
	      botones[ i ].addActionListener( this ); 
	        mypane.add( botones[i] );
	      }
	      add(mypane);
	      operacion=new String();
	      
	   }

	  
	   public void actionPerformed( ActionEvent evento )
	   { 
		   
		 if((((JButton) evento.getSource()).getText())=="=") {
			 
			 ScriptEngineManager mgr = new ScriptEngineManager();
			    ScriptEngine engine = mgr.getEngineByName("JavaScript");
			    String foo = operacion;
			    try {
			    	texto.setText(String.valueOf(engine.eval(foo)));
					//System.out.println(engine.eval(foo));
				} catch (ScriptException e) {
					// TODO Auto-generated catch block
					
					e.printStackTrace();
				}
		 }
		 else if((((JButton) evento.getSource()).getText())=="C") {
		   //operacion=operacion.concat((((JButton) evento.getSource()).getText()));
		   operator=false;
		   //System.out.println(operacion);
			operacion="";
		   texto.setText(operacion);
		   
		 }
		 else if (Arrays.asList(botonCalcu2).contains((((JButton) evento.getSource()).getText()))==true && operator==false) {
//			System.out.print("hola");
			operator=true;
			 operacion=operacion.concat((((JButton) evento.getSource()).getText()));
			   
//			   System.out.println(operacion);
			 texto.setText(operacion);
		 }
		 else if(Arrays.asList(botonCalcu3).contains((((JButton) evento.getSource()).getText()))==true){
			 operator=false;
			 operacion=operacion.concat((((JButton) evento.getSource()).getText()));
			   
//			   System.out.println(operacion);
			 texto.setText(operacion);
		 }
	      
	   } 
	}

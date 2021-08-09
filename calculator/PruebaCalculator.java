package calculadora;

import javax.script.ScriptEngine;
import javax.script.ScriptEngineManager;
import javax.script.ScriptException;
import javax.swing.JFrame;

public class PruebaCalculator {

	public static void main(String[] args) throws ScriptException {
	
				Calculator miCalculadora = new Calculator();
				miCalculadora.setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );
			      miCalculadora.setSize( 300, 600 ); // establece el tamaño del marco
			      miCalculadora.setVisible( true );
			    ScriptEngineManager mgr = new ScriptEngineManager();
			    ScriptEngine engine = mgr.getEngineByName("JavaScript");
//			    String foo = "(40-5)/5+3";
//			    System.out.println(engine.eval(foo));
			

	}

}

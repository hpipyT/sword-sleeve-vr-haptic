import java.util.Scanner;
class ServoEasy {
	public static void main(String args[]) {
		try
		{
			Runtime runTime = Runtime.getRuntime();
			runTime.exec("gpio mode 1 pwm");
			runTime.exec("gpio pwm-ms") ;
			runTime.exec("gpio pwmc 192");
			runTime.exec("gpio pwmr 2000");
	    	        Scanner myObj = new Scanner(System.in);  // Create a Scanner object
		        System.out.println("Waiting for input 1...");
			String input = myObj.nextLine();
			if (input.equals("1"))
			{
				runTime.exec("gpio pwm 1 152");
				Thread.sleep (5000);
				runTime.exec("gpio pwm 1 100"); // turn right
				Thread.sleep (3000);
				runTime.exec("gpio pwm 1 200"); // turn left
				Thread.sleep (3000);
			}


		}
		catch (Exception e)
		{
			System.out.println("Exception occured:" + e.getMessage());
		}
	}
}

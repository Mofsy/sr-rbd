package ddb;

public class TimeoutException extends Exception {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	
	public TimeoutException()
	{
		super("Timed out");
	}

}

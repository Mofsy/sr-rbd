using System;
using RBD.Msg;
using RBD.Restore.Msg;
using RBD.TPC.Msg;

namespace RBD.Restore {
    public class BlockedCohort : Worker
    {
	    private static string LOGGING_NAME = "BlockedCohort";
    	
	    public void ForbidTransaction()
	    {
		    try 
		    {
			    Message msg = accept(Message.MessageType.TPC_CANCOMMIT, null);
		        TcpSender.getInstance().sendToNode(new NoForCommitMessage(), msg.Sender);
    		
			    Logger.getInstance().log(
					    "Transaction forbidden", 
					    LOGGING_NAME, 
					    Logger.Level.INFO);
    		
		    } 
		    catch (TimeoutException e) 
		    {
			    Logger.getInstance().log(
					    "TimeoutException (should never happen)", 
					    LOGGING_NAME, 
					    Logger.Level.WARNING);
		    }
	    }
    	
	    public void run() {
    		
		    try {
			    while(true)
				    ForbidTransaction();
		    } catch (Exception e) {
			    Logger.getInstance().log(
					    "InterruptedException - terminating", 
					    LOGGING_NAME, 
					    Logger.Level.WARNING);
		    }
    		
	    }
    }
}

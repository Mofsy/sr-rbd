package ddb.restore.msg;

import java.io.IOException;

import ddb.communication.DataInputStream;
import ddb.communication.DataOutputStream;
import ddb.msg.MessageType;

public class RestoreNack extends RestoreMessage {

	@Override
	public void fromBinary(DataInputStream s) throws IOException {
		// empty
	}

	@Override
	public MessageType getType() {
		return MessageType.RESTORE_NACK;
	}

	@Override
	public void toBinary(DataOutputStream s) throws IOException {
		// empty
	}

}

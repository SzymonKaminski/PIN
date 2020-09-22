﻿using System;
using System.Collections.Generic;
using System.Text;

using MyGameServer.Packets;

namespace MyGameServer.Controllers {
	[ControllerID(Enums.GSS.Controllers.Generic)]
	public class Generic : Base {

		public override void Init( INetworkClient client, IPlayer player, IShard shard ) {
			
		}

		[MessageID((byte)Enums.GSS.Generic.Commands.ScheduleUpdateRequest)]
		public void ScheduleUpdateRequest( INetworkClient client, IPlayer player, ulong EntityID, GamePacket packet ) {
			// TODO: implement
			var req = packet.Read<Packets.GSS.Generic.ScheduleUpdateRequest>();
			//Program.Logger.Error("SUR: Requested Client Time: {0}", req.requestClientTime);

			var i = 0;
		}
	}
}
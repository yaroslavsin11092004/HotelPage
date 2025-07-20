import { useEffect } from "react";
interface ChangeBookingProps
{
	cId: string;
	cDateArrived: string;
	cDateDeparture: string;
	cNumberRoom: string;
	cName: string;
	cSurname: string;
	cStatus: string;
}
const ChangeBooking = ({cId, cDateArrived, cDateDeparture, cNumberRoom, cName, cSurname, cStatus}: ChangeBookingProps)=>
{
	const check_date:RegExp = /^\d{4}\.\d{2}\.\d{2}\s\d{2}:\d{2}:\d{2}\+\d{2}:\d{2}$/;
	if (check_date.test(cDateArrived) && check_date.test(cDateDeparture))
	{
		useEffect(()=>{
			const request = async()=>
			{
				await fetch('http://localhost:5000/api/bookings',{
					method: 'PUT',
					headers: {'Content-Type':'application/json'},
					body: JSON.stringify({
						'id':cId.replace('(id)', ''),
						'DateArrived':cDateArrived.replaceAll('.', '-').replace(' ', 'T'),
						'DateDeparture':cDateDeparture.replaceAll('.', '-').replace(' ', 'T'),
						'NumberRoom':cNumberRoom.replace('(Room)',''),
						'Name':cName,
						'Surname':cSurname,
						'Status':cStatus
					})
				}
			);
			};
			request();
		},[]);
		window.location.reload();
		return <></>;
	}
	else window.location.reload();
}
export default ChangeBooking;

import { useEffect,useState } from "react";
interface DeleteBookingProps
{
	dId:string;
}
const DeleteBooking = ({dId}:DeleteBookingProps)=>
{
	const [load,setLoad] = useState<number>(0);
	useEffect(()=>{
	const request = async()=>
	{
		setLoad(1);
		await fetch('http://localhost:5000/api/bookings/'+dId.replace('(id)',''), {
			method:'DELETE',
			headers:{'Content-Type':'application/json'}
		}
	);
	setLoad(2);
	};
	request();
	},[]);
	if (load === 2)window.location.reload();
	return <></>;
}
export default DeleteBooking;

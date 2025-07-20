import { useEffect } from "react";
interface ChangeGuestProps
{
	cId: string;
	cName: string;
	cSurname: string;
	cPhone : string;
	cEmail: string;
}
const ChangeGuest = ({cId, cName,cSurname, cPhone,cEmail} : ChangeGuestProps)=>
{
	useEffect(()=>{
	const request = async()=>
	{
		await fetch('http://localhost:5000/api/guests', {
			method: 'PUT',
			headers: {'Content-Type':'application/json'},
			body: JSON.stringify({
				'id':cId,
				'Name':cName,
				'Surname':cSurname,
				'Email':cEmail,
				'Phone':cPhone
			})
		}
		);
	};
	request();
	},[]);
	window.location.reload();
	return <></>;
}
export default ChangeGuest;


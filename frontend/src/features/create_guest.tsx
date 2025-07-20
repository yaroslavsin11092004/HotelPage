import { useEffect,useState } from "react";
interface CreateGuestProps
{
	cName: string;
	cSurname: string;
	cEmail: string;
	cPhone: string;
}
const CreateGuest = ({cName, cSurname, cEmail, cPhone}:CreateGuestProps)=>
{
	const check_phone_regex: RegExp = /^\+\d{1}\(\d{3}\)\d{3}-\d{2}-\d{2}$/;
	const check_email_regex : RegExp = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
	const [loading, setLoading] = useState<number>(0);
	if (check_phone_regex.test(cPhone) && check_email_regex.test(cEmail) && cSurname !== '' && cName !== '')
	{
		useEffect(()=>{
		const request = async()=>
		{
			setLoading(1);
			await fetch('http://localhost:5000/api/guests',{
				method:'POST',
				headers:{'Content-Type':'application/json'},
				body: JSON.stringify({
					'id':'0',
					'Name':cName,
					'Surname':cSurname,
					'Email':cEmail,
					'Phone':cPhone
				})
			}
			);
			setLoading(2);
		};
		request();
		},[]);
	}
	else setLoading(3);
	if (loading === 2)window.location.reload();
	else if (loading===3)window.location.reload();
	return <></>;
}
	export default CreateGuest;

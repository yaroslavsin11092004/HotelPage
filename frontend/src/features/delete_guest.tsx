import { useEffect,useState} from "react";
interface DeleteGuestProps
{
	dId: number;
}
const DeleteGuest = ({dId}:DeleteGuestProps)=>
{
	const [load, setLoad] = useState<number>(0);
	useEffect(()=>{
	const request = async()=>
	{
		setLoad(1);
		await fetch('http://localhost:5000/api/guests/' + dId.toString(), {
			method:'DELETE',
			headers: {'Content-Type':'application/json'}
		}
	);
	setLoad(2);
	};
	request();
	}, []);
	if (load === 2) window.location.reload();
	return (
		<></>
	);
}
export default DeleteGuest;


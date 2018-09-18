export const navigation = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    icon: 'icon-speedometer',
    badge: {
      variant: 'info',
      text: 'NEW'
    }
  }
];

export const requesterMenu = [
  {
    menuID: 6,
    menuIcon: '',
    menuSystemName: 'ประวัติใบขอใช้รถยนต์',
    menuSystemUrl: '/request/searchrequest',
    useFlag: true, childs: null
  },
  {
    menuID: 2,
    menuIcon: '',
    menuSystemName: 'บันทึกใบขอใช้รถยนต์',
    menuSystemUrl: '/request/addrequest',
    useFlag: true,
    childs: null
  },
  {
    menuID: 4,
    menuIcon: '',
    menuSystemName: 'ให้คะแนนใบขอใช้บริการรถยนต์',
    menuSystemUrl: '/request/rate',
    useFlag: true,
    childs: null
  }
];

export const adminMenu = [
  {
    menuID: 4,
    menuIcon: '',
    menuSystemName: 'อนุมัติใบขอใช้บริการรถยนต์',
    menuSystemUrl: '/request/searchapprove',
    useFlag: true, childs: null
  },
  {
    menuID: 7,
    menuIcon: '',
    menuSystemName: 'ประวัติใบมอบหมายงาน',
    menuSystemUrl: '/assign/view',
    useFlag: true, childs: null
  },
  {
    menuID: 3,
    menuIcon: '',
    menuSystemName: 'บันทึกใบมอบหมายงาน',
    menuSystemUrl: '/assign/add',
    useFlag: true,
    childs: null
  },
  {
    menuID: 5,
    menuIcon: '',
    menuSystemName: 'บันทึกค่าแรงใบขอใช้บริการรถยนต์',
    menuSystemUrl: '/request/pay',
    useFlag: true,
    childs: null
  },
  {
    menuID: 6,
    menuIcon: '',
    menuSystemName: 'อนุมัติรถยนต์ออกปฏิบัติงาน',
    menuSystemUrl: '/used/searchused',
    useFlag: true, childs: null
  },
  {
    menuID: 3,
    menuIcon: '',
    menuSystemName: 'ข้อมูลรายการรถยนต์',
    menuSystemUrl: '/cars/searchcars',
    useFlag: true, childs: null
  },
  {
    menuID: 2,
    menuIcon: '',
    menuSystemName: 'บันทึกข้อมูลรถยนต์',
    menuSystemUrl: '/cars/newcars',
    useFlag: true,
    childs: null
  },
  {
    menuID: 4,
    menuIcon: '',
    menuSystemName: 'บันทึกรายการซ่อมบำรุง',
    menuSystemUrl: '/cars/newmaintenance',
    useFlag: true, childs: null
  },
  {
    menuID: 5,
    menuIcon: '',
    menuSystemName: 'ข้อมูลรายการต่อภาษี-ทะเบียน-พรบ',
    menuSystemUrl: '/cars/searchdocumentcars',
    useFlag: true,
    childs: null
  },
  {
    menuID: 6,
    menuIcon: '',
    menuSystemName: 'ประวัติรายการซ่อมบำรุง',
    menuSystemUrl: '/cars/searchmaintenance',
    useFlag: true,
    childs: null
  }

];

export const securityMenu = [
  {
    menuID: 4,
    menuIcon: '',
    menuSystemName: 'ประวัติบันทึกรถเข้า-ออก',
    menuSystemUrl: '/security',
    useFlag: true,
    childs: null
  },


];


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
    menuSystemName: 'ข้อมูลใบขอใช้รถยนต์',
    menuSystemUrl: '/requests/search',
    useFlag: true,
    childs: null
  },
  {
    menuID: 2,
    menuIcon: '',
    menuSystemName: 'บันทึกใบขอใช้รถยนต์',
    menuSystemUrl: '/requests',
    useFlag: true,
    childs: null
  },
  {
    menuID: 7,
    menuIcon: '',
    menuSystemName: 'ประวัติใบมอบหมายงาน',
    menuSystemUrl: '/requests/assign/search',
    useFlag: true, childs: null
  },
  {
    menuID: 3,
    menuIcon: '',
    menuSystemName: 'บันทึกใบมอบหมายงาน',
    menuSystemUrl: '/requests/assign',
    useFlag: true,
    childs: null
  }
  /*
  {
    menuID: 4,
    menuIcon: '',
    menuSystemName: 'ให้คะแนนใบขอใช้บริการรถยนต์',
    menuSystemUrl: '/request/rate',
    useFlag: true,
    childs: null
  }*/
];

export const adminMenu = [
  {
    menuID: 1,
    menuIcon: 'icon-menu',
    menuSystemName: 'บันทึกใบขอรับบริการ',
    menuSystemUrl: '#',
    useFlag: true, childs: null
  },
  {
    menuID: 3,
    menuIcon: '',
    menuSystemName: 'บันทึกใบขอใช้รถยนต์',
    menuSystemUrl: '/requests',
    useFlag: true,
    childs: 1
  },
  {
    menuID: 7,
    menuIcon: '',
    menuSystemName: 'บันทึกใบมอบหมายงาน',
    menuSystemUrl: '/requests/assign',
    useFlag: true,
    childs: null
  },
  {
    menuID: 4,
    menuIcon: 'icon-menu',
    menuSystemName: 'อนุมัติใบขอรับบริการ',
    menuSystemUrl: '#',
    useFlag: true, childs: null
  },
  {
    menuID: 2,
    menuIcon: '',
    menuSystemName: 'ประวัติใบขอใช้บริการรถยนต์',
    menuSystemUrl: '/requests/search',
    useFlag: true,
    childs: 1
  },
  {
    menuID: 6,
    menuIcon: '',
    menuSystemName: 'ประวัติใบมอบหมายงาน',
    menuSystemUrl: '/requests/assign/search',
    useFlag: true, childs: null
  },
  {
    menuID: 4,
    menuIcon: 'icon-menu',
    menuSystemName: 'ประวัติใบขอรับบริการ',
    menuSystemUrl: '#',
    useFlag: true, childs: null
  },
  {
    menuID: 2,
    menuIcon: '',
    menuSystemName: 'ประวัติใบขอใช้บริการรถยนต์',
    menuSystemUrl: '/requests/search',
    useFlag: true,
    childs: 1
  },
  {
    menuID: 6,
    menuIcon: '',
    menuSystemName: 'ประวัติใบมอบหมายงาน',
    menuSystemUrl: '/assign/view',
    useFlag: true, childs: 4
  },
  {
    menuID: 4,
    menuIcon: 'icon-menu',
    menuSystemName: 'อนุม้ติรถออกปฏิบัติงาน',
    menuSystemUrl: '#',
    useFlag: true, childs: null
  },
  {
    menuID: 4,
    menuIcon: '',
    menuSystemName: 'อนุม้ติรถออกปฏิบัติงาน',
    menuSystemUrl: '#',
    useFlag: true, childs: null
  },
  {
    menuID: 4,
    menuIcon: 'icon-menu',
    menuSystemName: 'ข้อมูลรถออกปฏิบัติงาน',
    menuSystemUrl: '#',
    useFlag: true, childs: null
  },
  {
    menuID: 5,
    menuIcon: '',
    menuSystemName: 'ข้อมูลรถออกปฏิบัติงาน',
    menuSystemUrl: '/security',
    useFlag: true,
    childs: 4
  },
  {
    menuID: 4,
    menuIcon: 'icon-menu',
    menuSystemName: 'ข้อมูลรายการรถยนต์',
    menuSystemUrl: '#',
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
    menuID: 4,
    menuIcon: 'icon-menu',
    menuSystemName: 'รายงาน',
    menuSystemUrl: '#',
    useFlag: true, childs: null
  },
  {
    menuID: 4,
    menuIcon: '',
    menuSystemName: 'รายงาน-1',
    menuSystemUrl: '#',
    useFlag: true, childs: null
  },
  {
    menuID: 4,
    menuIcon: '',
    menuSystemName: 'รายงาน-2',
    menuSystemUrl: '#',
    useFlag: true, childs: null
  },
  {
    menuID: 4,
    menuIcon: '',
    menuSystemName: 'รายงาน-3',
    menuSystemUrl: '#',
    useFlag: true, childs: null
  },
  {
    menuID: 4,
    menuIcon: '',
    menuSystemName: 'รายงาน-4',
    menuSystemUrl: '#',
    useFlag: true, childs: null
  },
  {
    menuID: 4,
    menuIcon: '',
    menuSystemName: 'รายงาน-5',
    menuSystemUrl: '#',
    useFlag: true, childs: null
  },
  {
    menuID: 4,
    menuIcon: 'icon-menu',
    menuSystemName: 'การจัดการระบบ',
    menuSystemUrl: '#',
    useFlag: true, childs: null
  },
  {
    menuID: 3,
    menuIcon: '',
    menuSystemName: 'บันทึกข้อมูลผู้ใช้งานระบบ',
    menuSystemUrl: '/setup/user/search',
    useFlag: true,
    childs: null
  },
  {
    menuID: 4,
    menuIcon: '',
    menuSystemName: 'บันทึกข้อมูลแผนก',
    menuSystemUrl: '#',
    useFlag: true, childs: null
  },
  {
    menuID: 4,
    menuIcon: '',
    menuSystemName: 'บันทึกข้อมูลฝ่าย',
    menuSystemUrl: '#',
    useFlag: true, childs: null
  },
  {
    menuID: 3,
    menuIcon: '',
    menuSystemName: 'บันทึกข้อมูลพนักงานขับรถ',
    menuSystemUrl: '/setup/driver/search',
    useFlag: true,
    childs: null
  },
  {
    menuID: 5,
    menuIcon: '',
    menuSystemName: 'บันทึกวัตถุประสงค์การเดินทาง',
    menuSystemUrl: '/setup/foruse/search',
    useFlag: true,
    childs: 3
  },
  {
    menuID: 9,
    menuIcon: '',
    menuSystemName: 'บันทึกข้อมูลสถานที่',
    menuSystemUrl: '/setup/place/search',
    useFlag: true,
    childs: null
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
    menuID: 2,
    menuIcon: '',
    menuSystemName: 'บันทึกข้อมูลประเภทรถยนต์',
    menuSystemUrl: '#',
    useFlag: true,
    childs: null
  },
  {
    menuID: 9,
    menuIcon: '',
    menuSystemName: 'บันทึกข้อมูลแจ้งพนักงาน',
    menuSystemUrl: '/setup/information/search',
    useFlag: true,
    childs: null
  }
  /*,
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
*/
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

